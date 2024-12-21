using MyExamsBackend.DTOs.UserDTOs;
using MyExamsBackend.Models;

namespace MyExamsBackend.Services.Interfaces
{
    public interface IUsersService
    {
        public List<User> GetAll();
        public UserResponseDTO GetById(int id);
        public bool Update(UpdateUserRequestDTO updateUser);
        public bool Delete(int id);
    }
}
