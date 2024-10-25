using CMCSWebApp.Data.Enum;
using System.ComponentModel.DataAnnotations;

namespace CMCSWebApp.Models
{
    public class Users
    {
        [Key]
        public int ID { get; set; } // Primary key

        [Required(ErrorMessage = "Username is required.")]
        [StringLength(50, ErrorMessage = "Username cannot be longer than 50 characters.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters long.")]
        public string Password { get; set; }

 
        [Required(ErrorMessage = "Role is required.")]
        public UserRole Role { get; set; } // Using Role enum to define user roles

    }
}
