using MyExamsBackend.Models;
using System.ComponentModel.DataAnnotations;

namespace MyExamsBackend.DTOs.ExamDTOs
{
    public class UpdateExamRequestDTO
    {
        public int Id { get; set; }
        [Required]
        [MinLength(5, ErrorMessage = "The name of the exam be at least 5 characaters long")]
        [MaxLength(70, ErrorMessage = "The name of the exam must not exceed 70 characaters")]
        public string? Name { get; set; }
        public string? ImageSrc { get; set;}
        [MinLength(10, ErrorMessage = "The description of the exam be at least 10 characaters long")]
        [MaxLength(255, ErrorMessage = "The description of the exam must not exceed 255 characaters")]
        public string? Description { get; set; }
        [Required]
        public int ProgrammingLanguageId { get; set; }
    }
}
    

