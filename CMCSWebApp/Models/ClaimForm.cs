using CMCSWebApp.Data.Enum;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CMCSWebApp.Models
{
    public class ClaimForm
    {
        [Key]
        public int ClaimID { get; set; }

        [Required(ErrorMessage = "Lecturer's name is required.")]
        [StringLength(100)]
        public string LecturerName { get; set; }

        [Required(ErrorMessage = "Lecturer's surname is required.")]
        [StringLength(100)]
        public string LecturerSurname { get; set; }

        [Required(ErrorMessage = "Employee number is required.")]
        public string EmployeeNumber { get; set; }

        [Required(ErrorMessage = "Contact details are required.")]
        [Phone(ErrorMessage = "Invalid phone number format.")]
        public string ContactDetails { get; set; } // Accommodates different formats

        [Required(ErrorMessage = "Programme name is required.")]
        [StringLength(100)]
        public string Programme { get; set; }

        [Required(ErrorMessage = "Module name is required.")]
        [StringLength(100)]
        public string Module { get; set; }

        [Required(ErrorMessage = "Hours worked is required.")]
        [Range(0, 168, ErrorMessage = "Hours worked must be between 0 and 168.")]
        public int HoursWorked { get; set; }

        [Required(ErrorMessage = "Hourly rate is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Hourly rate must be a positive value.")]
        public decimal HourlyRate { get; set; }

        [Required(ErrorMessage = "Submission date is required.")]
        public DateOnly SubmissionDate { get; set; }

        public ICollection<ItemsFeature> SupportingDocs { get; set; }  // Collection of supporting documents

        // Constructor
        public ClaimForm()
        {
            SupportingDocs = new List<ItemsFeature>();
        }
    }
}
