using MyExamsBackend.Models;

namespace MyExamsBackend.DTOs.ProgrammingLanguageDTOs
{
    public class CreateProgrammingLanguageRequestDTO
    {
        public string Name { get; set; }
        public string ImageSrc { get; set; }
        public string Description { get; set; }
    }
}
