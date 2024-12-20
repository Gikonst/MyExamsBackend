using MyExamsBackend.DTOs.AnswerDTOs;
using MyExamsBackend.Models;

namespace MyExamsBackend.DTOs.QuestionDTOs
{
    public class QuestionResponseDTO
    {
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public List<AnswerResponseDTO> Answers { get; set; }
    }
}
