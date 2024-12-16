using MyExamsBackend.DTOs.ProgrammingLanguageDTOs;
using MyExamsBackend.DTOs.UserDTOs;
using MyExamsBackend.Models;

namespace MyExamsBackend.DTOs.ExamDTOs
{
    public class ExamResponseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProgrammingLanguageId { get; set; }
        public ProgrammingLanguageDTO ProgrammingLanguage { get; set; }
        public List<Question> Questions { get; set; }

        public ExamResponseDTO()
        {
            Questions = new List<Question>();
        }
    }
}
