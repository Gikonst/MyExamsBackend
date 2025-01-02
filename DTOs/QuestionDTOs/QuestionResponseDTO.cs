using MyExamsBackend.DTOs.AnswerDTOs;
using MyExamsBackend.DTOs.ExamDTOs;
using MyExamsBackend.Models;

namespace MyExamsBackend.DTOs.QuestionDTOs
{
    public class QuestionResponseDTO
    {
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public List<AnswerResponseDTO> Answers { get; set; }
        public List<ExamResponseQuestionDTO> Exams { get; set; }
    }
}
