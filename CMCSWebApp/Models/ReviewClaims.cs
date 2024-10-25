using CMCSWebApp.Data.Enum;
using System.ComponentModel.DataAnnotations;

namespace CMCSWebApp.Models
{
    public class ReviewClaims
    {
        [Key]
        public int ClaimID { get; set; }
        public string LecturerName { get; set; }
        public string LecturerSurname { get; set; }
        public string LecturerEmployeeNo { get; set; }
        public string Programme { get; set; }
        public string Module { get; set; }
        public string ContactDetails { get; set; }
        public int HoursWorked { get; set; }
        public decimal HourlyRate { get; set; }
        public DateOnly SubmissionDate { get; set; }
        public string SupportingDocs { get; set; } // Store paths to supporting documents
        
    }
}
