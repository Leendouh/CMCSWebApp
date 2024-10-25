using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CMCSWebApp.Tests.LecturerTests
{
    public class LecturerTests
    {
        private readonly Mock<IClaimRepository> _claimRepositoryMock;
        private readonly ClaimService _claimService;

        public LecturerTests()
        {
            _claimRepositoryMock = new Mock<IClaimRepository>();
            _claimService = new ClaimService(_claimRepositoryMock.Object);
        }

        [Fact]
        public async Task SubmitClaim_LecturerCanSubmitClaim_Success()
        {
            // Arrange
            var lecturerId = 1;
            var claim = new Claim { LecturerId = lecturerId, Amount = 500, Status = "Pending" };
            _claimRepositoryMock.Setup(repo => repo.AddClaimAsync(It.IsAny<Claim>())).ReturnsAsync(claim);

            // Act
            var result = await _claimService.SubmitClaimAsync(claim);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Pending", result.Status);
            _claimRepositoryMock.Verify(repo => repo.AddClaimAsync(It.IsAny<Claim>()), Times.Once);
        }

        [Fact]
        public async Task GetClaims_LecturerCanViewOnlyTheirClaims()
        {
            // Arrange
            var lecturerId = 1;
            var claims = new List<Claim>
        {
            new Claim { LecturerId = lecturerId, Amount = 300 },
            new Claim { LecturerId = lecturerId, Amount = 500 }
        };
            _claimRepositoryMock.Setup(repo => repo.GetClaimsByLecturerIdAsync(lecturerId)).ReturnsAsync(claims);

            // Act
            var result = await _claimService.GetClaimsByLecturerAsync(lecturerId);

            // Assert
            Assert.Equal(2, result.Count);
            Assert.All(result, c => Assert.Equal(lecturerId, c.LecturerId));
        }
    }
}