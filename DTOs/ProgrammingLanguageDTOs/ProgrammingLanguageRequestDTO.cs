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
    }
}
