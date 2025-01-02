using MyExamsBackend.DTOs.UserDTOs;
using MyExamsBackend.Models;

namespace MyExamsBackend.Services.Interfaces
{
    public interface IUsersService
    {
        public Task<List<User>> GetAllAsync();
        public Task<UserResponseDTO> GetByIdAsync(int id);
        public Task<bool> UpdateAsync(UpdateUserRequestDTO updateUser);
        public Task<bool> DeleteAsync(int id);
    }
}
