using CMCSWebApp.Models;
using System;
using Xunit;
using FluentAssertions;

namespace CMCSWebApp.Tests.Models
{
    public class ReviewClaimsTests
    {
        [Fact]
        public void ReviewClaims_WhenAllPropertiesAreSet_ShouldBeValid()
        {
            // Arrange
            var reviewClaims = new ReviewClaims
            {
                ClaimID = 1,
                LecturerName = "John",
                LecturerSurname = "Doe",
                LecturerEmployeeNo = "EMP12345",
                Programme = "Software Engineering",
                Module = "Software Testing",
                ContactDetails = "123-456-7890",
                HoursWorked = 40,
                HourlyRate = 50.75m,
                SubmissionDate = new DateOnly(2024, 10, 25),
                SupportingDocs = "/path/to/docs"
            };

            // Assert
            reviewClaims.ClaimID.Should().Be(1);
            reviewClaims.LecturerName.Should().Be("John");
            reviewClaims.LecturerSurname.Should().Be("Doe");
            reviewClaims.LecturerEmployeeNo.Should().Be("EMP12345");
            reviewClaims.Programme.Should().Be("Software Engineering");
            reviewClaims.Module.Should().Be("Software Testing");
            reviewClaims.ContactDetails.Should().Be("123-456-7890");
            reviewClaims.HoursWorked.Should().Be(40);
            reviewClaims.HourlyRate.Should().Be(50.75m);
            reviewClaims.SubmissionDate.Should().Be(new DateOnly(2024, 10, 25));
            reviewClaims.SupportingDocs.Should().Be("/path/to/docs");
        }

        [Fact]
        public void ReviewClaims_WhenHoursWorkedIsNegative_ShouldFailValidation()
        {
            // Arrange
            var reviewClaims = new ReviewClaims
            {
                HoursWorked = -5 // Invalid negative value
            };

            // Act & Assert
            reviewClaims.HoursWorked.Should().BeLessThan(0, "HoursWorked should not be negative.");
        }

        [Fact]
        public void ReviewClaims_WhenHourlyRateIsNegative_ShouldFailValidation()
        {
            // Arrange
            var reviewClaims = new ReviewClaims
            {
                HourlyRate = -100.00m // Invalid negative value
            };

            // Act & Assert
            reviewClaims.HourlyRate.Should().BeNegative("HourlyRate should not be negative.");
        }

        [Fact]
        public void ReviewClaims_WhenSupportingDocsPathIsSet_ShouldBeCorrect()
        {
            // Arrange
            var reviewClaims = new ReviewClaims
            {
                SupportingDocs = "/path/to/docs"
            };

            // Assert
            reviewClaims.SupportingDocs.Should().Be("/path/to/docs");
        }
    }
}
