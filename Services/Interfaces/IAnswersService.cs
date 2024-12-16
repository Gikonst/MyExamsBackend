using MyExamsBackend.DTOs.AnswerDTOs;
using MyExamsBackend.Models;

namespace MyExamsBackend.Services.Interfaces
{
    public interface IAnswersService
    {
        public List<AnswerResponseDTO> GetAll();
        public AnswerResponseDTO GetById(int id);
        public bool Create(CreateAnswerRequestDTO createAnswerRequestDto);
        public bool Update(UpdateAnswerRequestDTO updateAnswerRequestDto);
        public bool Delete(int id);

    }
}
