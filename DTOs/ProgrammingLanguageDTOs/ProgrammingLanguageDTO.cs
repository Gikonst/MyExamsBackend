using MyExamsBackend.DTOs.ExamDTOs;
using MyExamsBackend.Models;

namespace MyExamsBackend.DTOs.ProgrammingLanguageDTOs
{
    public class ProgrammingLanguageDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageSrc { get; set; }
        public string Description { get; set; }
        public List<ExamResponseDTO> Exams { get; set; }
        public ProgrammingLanguageDTO()
        {
            Exams = new List<ExamResponseDTO>();
        }
    }
}
