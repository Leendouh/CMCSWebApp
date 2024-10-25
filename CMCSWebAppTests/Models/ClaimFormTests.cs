using CMCSWebApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Xunit;
using FluentAssertions;

namespace CMCSWebApp.Tests.Models
{
    public class ClaimFormTests
    {
        private ClaimForm CreateValidClaimForm()
        {
            return new ClaimForm
            {
                ClaimID = 1,
                LecturerName = "John",
                LecturerSurname = "Doe",
                EmployeeNumber = "EMP12345",
                ContactDetails = "123-456-7890",
                Programme = "Software Engineering",
                Module = "Software Testing",
                HoursWorked = 40,
                HourlyRate = 100,
                SubmissionDate = new DateOnly(2024, 10, 25),
                SupportingDocs = new List<ItemsFeature>() // Add mock data if necessary
            };
        }

        [Fact]
        public void ClaimForm_WithValidData_ShouldBeValid()
        {
            // Arrange
            var claimForm = CreateValidClaimForm();

            // Act
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(claimForm);
            var isValid = Validator.TryValidateObject(claimForm, validationContext, validationResults, true);

            // Assert
            isValid.Should().BeTrue();
            validationResults.Should().BeEmpty();
        }

        [Fact]
        public void ClaimForm_WhenLecturerNameIsMissing_ShouldFailValidation()
        {
            // Arrange
            var claimForm = CreateValidClaimForm();
            claimForm.LecturerName = null;

            // Act
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(claimForm);
            var isValid = Validator.TryValidateObject(claimForm, validationContext, validationResults, true);

            // Assert
            isValid.Should().BeFalse();
            validationResults.Should().ContainSingle(result => result.ErrorMessage.Contains("Lecturer's name is required."));
        }

        [Fact]
        public void ClaimForm_WhenHoursWorkedIsOutOfRange_ShouldFailValidation()
        {
            // Arrange
            var claimForm = CreateValidClaimForm();
            claimForm.HoursWorked = 200; // Out of valid range

            // Act
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(claimForm);
            var isValid = Validator.TryValidateObject(claimForm, validationContext, validationResults, true);

            // Assert
            isValid.Should().BeFalse();
            validationResults.Should().ContainSingle(result => result.ErrorMessage.Contains("Hours worked must be between 0 and 168."));
        }

        [Fact]
        public void ClaimForm_WhenHourlyRateIsZero_ShouldFailValidation()
        {
            // Arrange
            var claimForm = CreateValidClaimForm();
            claimForm.HourlyRate = 0; // Invalid rate

            // Act
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(claimForm);
            var isValid = Validator.TryValidateObject(claimForm, validationContext, validationResults, true);

            // Assert
            isValid.Should().BeFalse();
            validationResults.Should().ContainSingle(result => result.ErrorMessage.Contains("Hourly rate must be a positive value."));
        }

        [Fact]
        public void ClaimForm_WhenContactDetailsAreInvalid_ShouldFailValidation()
        {
            // Arrange
            var claimForm = CreateValidClaimForm();
            claimForm.ContactDetails = "InvalidPhoneNumber"; // Not a phone number

            // Act
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(claimForm);
            var isValid = Validator.TryValidateObject(claimForm, validationContext, validationResults, true);

            // Assert
            isValid.Should().BeFalse();
            validationResults.Should().ContainSingle(result => result.ErrorMessage.Contains("Invalid phone number format."));
        }
    }
}
