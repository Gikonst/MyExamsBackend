using MyExamsBackend.Models;

namespace MyExamsBackend.DTOs.AnswerDTOs
{
    public class UpdateAnswerRequestDTO
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public string AnswerText { get; set; }
        public bool IsCorrect { get; set; }
    }
}
