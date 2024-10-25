using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace CMCSWebApp.Models
{
    public class Programme
    {
        [Key]
        public int ProgrammeID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Module> Modules { get; set; }
    }
}
