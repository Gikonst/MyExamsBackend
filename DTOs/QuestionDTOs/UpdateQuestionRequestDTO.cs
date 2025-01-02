using System.ComponentModel.DataAnnotations;

namespace MyExamsBackend.DTOs.QuestionDTOs
{
    public class UpdateQuestionRequestDTO
    {
        public int Id { get; set; }
        [Required]

        public string QuestionText { get; set; }
        [Required]
        public int ExamId { get; set; }
    }
}
