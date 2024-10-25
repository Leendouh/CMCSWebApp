using CMCSWebApp.Data.Enum;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CMCSWebApp.Models
{
    public class Roles
    {
        [Key]
        public int RoleID { get; set; }
        public string Name { get; set; } // Lecturer, Program Coordinator, Academic Manager

        public ICollection<Users> Users { get; set; }
    }
}
