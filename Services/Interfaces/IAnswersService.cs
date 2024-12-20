using MyExamsBackend.DTOs.AnswerDTOs;
using MyExamsBackend.Models;

namespace MyExamsBackend.Services.Interfaces
{
    public interface IAnswersService
    {
        public List<AnswerResponseDTO> GetAll();
        public AnswerResponseDTO GetById(int id);
        public bool Create(AnswerRequestDTO createAnswerRequestDto);
        public bool Update(AnswerRequestDTO updateAnswerRequestDto);
        public bool Delete(int id);

    }
}
