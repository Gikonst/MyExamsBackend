using System.ComponentModel.DataAnnotations;

namespace MyExamsBackend.DTOs.UserDTOs
{
    public class RegisterUserDTO
    {
        [Required]
        [MinLength(2, ErrorMessage = "The First Name be at least 2 characters.")]
        [MaxLength(50, ErrorMessage = "The First Name must not exceed 50 characters.")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "The First Name be at least 2 characters.")]
        [MaxLength(50, ErrorMessage = "The Last Name must not exceed 50 characters.")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters long")]
        [MaxLength(16, ErrorMessage = "The Password must not exceed 16 characters.")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }
    }
}
