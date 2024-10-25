using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMCSWebApp.Models
{
    public class ItemsFeature
    {
        public int ItemID { get; set; }
        public string DocumentPath { get; set; }

        // Foreign key to ClaimForm
        public int ClaimID { get; set; }

        // Navigation property
        [ForeignKey("ClaimID")]
        public virtual ClaimForm ClaimForm { get; set; }
    }

}
