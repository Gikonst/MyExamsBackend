using MyExamsBackend.Models;

namespace MyExamsBackend.DTOs.ProgrammingLanguageDTOs
{
    public class UpdateProgrammingLanguageRequestDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageSrc { get; set; }
        public string Description { get; set; }

    }
}
