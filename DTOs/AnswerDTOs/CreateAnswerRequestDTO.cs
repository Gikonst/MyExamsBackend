using MyExamsBackend.Models;
using System.ComponentModel.DataAnnotations;

namespace MyExamsBackend.DTOs.AnswerDTOs
{
    public class CreateAnswerRequestDTO
    {
        public int Id { get; set; }
        [Required]
        public int QuestionId { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "Answers must not exceed 100 characters")]
        public string AnswerText { get; set; }
        [Required]
        public bool IsCorrect { get; set; }
    }
}
