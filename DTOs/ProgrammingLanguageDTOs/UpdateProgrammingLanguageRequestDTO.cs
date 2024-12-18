using MyExamsBackend.Models;
using System.ComponentModel.DataAnnotations;

namespace MyExamsBackend.DTOs.ProgrammingLanguageDTOs
{
    public class UpdateProgrammingLanguageRequestDTO
    {
        public int Id { get; set; }
        [MaxLength(15, ErrorMessage = "The name of the exam must not exceed 15 characaters")]
        public string Name { get; set; }
        [Required]
        public string ImageSrc { get; set; }
        [Required]
        [MinLength(250, ErrorMessage = "The name of the exam must not exceed 250 characaters")]
        [MaxLength(250, ErrorMessage = "The name of the exam must not exceed 250 characaters")]
        public string Description { get; set; }

    }
}
