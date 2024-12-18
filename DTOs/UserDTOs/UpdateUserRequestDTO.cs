using MyExamsBackend.Models;
using System.ComponentModel.DataAnnotations;

namespace MyExamsBackend.DTOs.UserDTOs
{
    public class UpdateUserRequestDTO
    {
        public int Id { get; set; }

        [MinLength(2, ErrorMessage = "First Name must be at least 2 characters long")]
        [MaxLength(50, ErrorMessage = "The First Name must not exceed 50 characters.")]
        public string FirstName { get; set; }

        [MinLength(2, ErrorMessage = "Last Name must be at least 2 characters long")]
        [MaxLength(50, ErrorMessage = "The Last Name must not exceed 50 characters.")]
        public string LastName { get; set; }
    }
}
