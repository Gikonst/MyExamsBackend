using MyExamsBackend.Models;

namespace MyExamsBackend.DTOs.UserDTOs
{
    public class CreateUserRequestDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; } 

    }
}
