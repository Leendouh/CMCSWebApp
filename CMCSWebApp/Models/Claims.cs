using CMCSWebApp.Data.Enum;
using System.ComponentModel.DataAnnotations;

namespace CMCSWebApp.Models
{
    public class Claims
    {
        [Key]
        public int ClaimsID { get; set; } // Primary key
        public string EmployeeNo { get; set; }
        public string Programme { get; set; }
        public string Module { get; set; }
        public int HoursWorked { get; set; }
        public decimal TotalAmount { get; set; }
        public DateOnly SubmissionDate { get; set; }
        public ClaimStatus Status { get; set; } // Each Claims is associated with one User


    }
}
