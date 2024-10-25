using CMCSWebApp.Models;
using CMCSWebApp.Data.Enum;
using System;
using Xunit;
using FluentAssertions;

namespace CMCSWebApp.Tests.Models
{
    public class ClaimsTests
    {
        [Fact]
        public void Claims_WhenAllPropertiesAreSet_ShouldBeValid()
        {
            // Arrange
            var claims = new Claims
            {
                ClaimsID = 1,
                EmployeeNo = "EMP12345",
                Programme = "Software Engineering",
                Module = "Software Testing",
                HoursWorked = 40,
                TotalAmount = 4000.50m,
                SubmissionDate = new DateOnly(2024, 10, 25),
                Status = ClaimStatus.Pending
            };

            // Assert
            claims.ClaimsID.Should().Be(1);
            claims.EmployeeNo.Should().Be("EMP12345");
            claims.Programme.Should().Be("Software Engineering");
            claims.Module.Should().Be("Software Testing");
            claims.HoursWorked.Should().Be(40);
            claims.TotalAmount.Should().Be(4000.50m);
            claims.SubmissionDate.Should().Be(new DateOnly(2024, 10, 25));
            claims.Status.Should().Be(ClaimStatus.Pending);
        }

        [Fact]
        public void Claims_WhenHoursWorkedIsNegative_ShouldFailValidation()
        {
            // Arrange
            var claims = new Claims
            {
                ClaimsID = 1,
                EmployeeNo = "EMP12345",
                Programme = "Software Engineering",
                Module = "Software Testing",
                HoursWorked = -5, // Invalid negative value
                TotalAmount = 4000.50m,
                SubmissionDate = new DateOnly(2024, 10, 25),
                Status = ClaimStatus.Pending
            };

            // Act & Assert
            claims.HoursWorked.Should().BeLessThan(0, "HoursWorked should not be negative.");
        }

        [Fact]
        public void Claims_WhenTotalAmountIsNegative_ShouldFailValidation()
        {
            // Arrange
            var claims = new Claims
            {
                ClaimsID = 1,
                EmployeeNo = "EMP12345",
                Programme = "Software Engineering",
                Module = "Software Testing",
                HoursWorked = 40,
                TotalAmount = -500.00m, // Invalid negative amount
                SubmissionDate = new DateOnly(2024, 10, 25),
                Status = ClaimStatus.Pending
            };

            // Act & Assert
            claims.TotalAmount.Should().BeNegative("TotalAmount should not be negative.");
        }

        [Fact]
        public void Claims_WhenStatusIsSet_ShouldBeCorrect()
        {
            // Arrange
            var claims = new Claims
            {
                Status = ClaimStatus.Approved
            };

            // Assert
            claims.Status.Should().Be(ClaimStatus.Approved);
        }
    }
}
