using System.ComponentModel.DataAnnotations;

namespace cleanArch.Mvc.Models
{
    public class RegisterViewModel
    {
        [Required]
        public string UserID { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        [Required]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters long.")]
        public string Password { get; set; }
    }
}
