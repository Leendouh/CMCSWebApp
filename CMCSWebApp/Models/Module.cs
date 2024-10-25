using System.ComponentModel.DataAnnotations;

namespace CMCSWebApp.Models
{
    public class Module
    {
        [Key]
        public int ModuleID { get; set; } // Primary key
        public string Name { get; set; }
        public string Description { get; set; }

        // Foreign key to link with Program (if necessary)
        public int ProgrammeID { get; set; }
        public Programme Programme { get; set; } // Navigation property
    }
}
