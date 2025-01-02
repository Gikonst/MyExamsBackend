using MyExamsBackend.DTOs.QuestionDTOs;
using MyExamsBackend.Models;

namespace MyExamsBackend.Services.Interfaces
{
    public interface IQuestionsService
    {
        public Task<List<QuestionResponseDTO>> GetAllAsync();
        public Task<Question> GetByIdAsync(int id);
        public Task<bool> CreateAsync(QuestionRequestDTO newQuestion);
        public Task<bool> UpdateAsync(UpdateQuestionRequestDTO question);
        public Task<bool> DeleteAsync(int id);
    }
}
