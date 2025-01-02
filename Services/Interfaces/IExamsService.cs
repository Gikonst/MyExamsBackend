using MyExamsBackend.DTOs.ExamDTOs;
using MyExamsBackend.DTOs.TestDTOs;
using MyExamsBackend.Models;

namespace MyExamsBackend.Services.Interfaces
{
    public interface IExamsService
    {
        public Task<List<ExamResponseDTO>> GetAllAsync();
        public Task<ExamResponseDTO> GetByIdAsync(int id);
        public Task<(double Score, bool Passed)> CalculateScoreAsync(int examId, List<TestUserAnswersDTO> userAnswers);
        public Task<bool> CreateAsync(CreateExamRequestDTO createExamRequestDto);
        public Task<bool> UpdateAsync(UpdateExamRequestDTO updateExamRequestDto);
        public Task<bool> DeleteAsync(int id);
    }
}
