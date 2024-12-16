using MyExamsBackend.DTOs.ExamDTOs;
using MyExamsBackend.Models;

namespace MyExamsBackend.Services.Interfaces
{
    public interface IExamsService
    {
        public List<ExamResponseDTO> GetAll();
        public ExamResponseDTO GetById(int id);
        public bool Create(CreateExamRequestDTO createExamRequestDto);
        public bool Update(UpdateExamRequestDTO updateExamRequestDto);
        public bool Delete(int id);
    }
}
