using CMCSWebApp.Data.Enum;
using System.ComponentModel.DataAnnotations;

namespace CMCSWebApp.Models
{
    public class SubmittedClaims
    {
        [Key]
        public int ClaimID { get; set; } // Foreign key to ClaimForm
        public string EmployeeNo { get; set; } // Employee number
        public string Programme { get; set; } // Programme associated with the claim
        public string Module { get; set; } // Modules associated with the claim
        public decimal Hours { get; set; } // Total hours claimed
        public decimal Total { get; set; } // Total amount claimed
        public DateTime Date { get; set; } // Date of submission
        public ClaimStatus Status { get; set; } // Current status of the claim
      
    }
}
