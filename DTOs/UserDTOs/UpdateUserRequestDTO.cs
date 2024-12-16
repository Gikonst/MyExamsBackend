using MyExamsBackend.Models;

namespace MyExamsBackend.DTOs.UserDTOs
{
    public class UpdateUserRequestDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
