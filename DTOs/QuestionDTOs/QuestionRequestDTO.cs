using System.ComponentModel.DataAnnotations;

namespace MyExamsBackend.DTOs.QuestionDTOs
{
    public class QuestionRequestDTO
    {
        [Required]
        [MinLength(15, ErrorMessage = "The question must be at least 15 characaters")]
        [MaxLength(200, ErrorMessage = "The question must not exceed 200 characaters")]
        public string QuestionText { get; set; }
    }
}
