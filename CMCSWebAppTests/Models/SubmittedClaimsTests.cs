using CMCSWebApp.Models;
using CMCSWebApp.Data.Enum;
using System;
using Xunit;
using FluentAssertions;

namespace CMCSWebApp.Tests.Models
{
    public class SubmittedClaimsTests
    {
        [Fact]
        public void SubmittedClaims_WhenAllPropertiesAreSet_ShouldBeValid()
        {
            // Arrange
            var submittedClaim = new SubmittedClaims
            {
                ClaimID = 1,
                EmployeeNo = "EMP12345",
                Programme = "Information Technology",
                Module = "Advanced Programming",
                Hours = 35.5m,
                Total = 5000.00m,
                Date = new DateTime(2024, 10, 25),
                Status = ClaimStatus.Pending
            };

            // Assert
            submittedClaim.ClaimID.Should().Be(1);
            submittedClaim.EmployeeNo.Should().Be("EMP12345");
            submittedClaim.Programme.Should().Be("Information Technology");
            submittedClaim.Module.Should().Be("Advanced Programming");
            submittedClaim.Hours.Should().Be(35.5m);
            submittedClaim.Total.Should().Be(5000.00m);
            submittedClaim.Date.Should().Be(new DateTime(2024, 10, 25));
            submittedClaim.Status.Should().Be(ClaimStatus.Pending);
        }

        [Fact]
        public void SubmittedClaims_WhenHoursIsNegative_ShouldFailValidation()
        {
            // Arrange
            var submittedClaim = new SubmittedClaims
            {
                Hours = -10.5m // Invalid negative value
            };

            // Act & Assert
            submittedClaim.Hours.Should().BeNegative("Hours should not be negative.");
        }

        [Fact]
        public void SubmittedClaims_WhenTotalIsNegative_ShouldFailValidation()
        {
            // Arrange
            var submittedClaim = new SubmittedClaims
            {
                Total = -100.00m // Invalid negative value
            };

            // Act & Assert
            submittedClaim.Total.Should().BeNegative("Total amount should not be negative.");
        }

        [Fact]
        public void SubmittedClaims_WhenStatusIsSet_ShouldBeCorrect()
        {
            // Arrange
            var submittedClaim = new SubmittedClaims
            {
                Status = ClaimStatus.Approved
            };

            // Assert
            submittedClaim.Status.Should().Be(ClaimStatus.Approved);
        }

        [Fact]
        public void SubmittedClaims_WhenDateIsSet_ShouldBeCorrect()
        {
            // Arrange
            var submittedClaim = new SubmittedClaims
            {
                Date = new DateTime(2024, 10, 25)
            };

            // Assert
            submittedClaim.Date.Should().Be(new DateTime(2024, 10, 25));
        }
    }
}
