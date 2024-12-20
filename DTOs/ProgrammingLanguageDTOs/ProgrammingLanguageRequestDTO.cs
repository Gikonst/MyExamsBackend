using MyExamsBackend.Models;
using System.ComponentModel.DataAnnotations;

namespace MyExamsBackend.DTOs.ProgrammingLanguageDTOs
{
    public class ProgrammingLanguageRequestDTO

    {
        public int Id { get; set; }
        [Required]
        [MaxLength(15, ErrorMessage = "The name of the exam must not exceed 15 characaters")]
        public string Name { get; set; }
        [Required]
        public string ImageSrc { get; set; }
        [Required]
        [MinLength(8, ErrorMessage = "The description must be at least 8 characaters")]
        [MaxLength(250, ErrorMessage = "The description of the exam must not exceed 250 characaters")]
        public string Description { get; set; }
    }
}
