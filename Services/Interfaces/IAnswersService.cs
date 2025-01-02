using MyExamsBackend.DTOs.AnswerDTOs;
using MyExamsBackend.Models;

namespace MyExamsBackend.Services.Interfaces
{
    public interface IAnswersService
    {
        public Task <List<AnswerResponseDTO>> GetAllAsync();
        public Task<AnswerResponseDTO> GetByIdAsync(int id);
        public Task<bool> CreateAsync(AnswerRequestDTO createAnswerRequestDto);
        public Task<bool> UpdateAsync(AnswerRequestDTO updateAnswerRequestDto);
        public Task<bool> DeleteAsync(int id);

    }
}
