using MyExamsBackend.DTOs.ExamDTOs;
using MyExamsBackend.DTOs.TestDTOs;
using MyExamsBackend.Models;

namespace MyExamsBackend.Services.Interfaces
{
    public interface IExamsService
    {
        public List<ExamResponseDTO> GetAll();
        public ExamResponseDTO GetById(int id);
        public (double Score, bool Passed) CalculateScore(int examId, List<TestUserAnswersDTO> userAnswers);
        public bool Create(CreateExamRequestDTO createExamRequestDto);
        public bool Update(UpdateExamRequestDTO updateExamRequestDto);
        public bool Delete(int id);
    }
}
