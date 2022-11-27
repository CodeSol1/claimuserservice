using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClaimUserService.Models
{
    public class User
    {
        public int UserId { get; set; }
        [Required(ErrorMessage = "Email is must")]
        //[RegularExpression()]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is must")]
        [MinLength(6, ErrorMessage = "Min 6 chgatcters rae needed")]
        public string Password { get; set; }
        [NotMapped]
        [Required(ErrorMessage = "Password is must")]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string RePassword { get; set; }

        [Required(ErrorMessage = "Role is must")]
        public int Role { get; set; }
    }
}
