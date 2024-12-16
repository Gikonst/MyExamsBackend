using MyExamsBackend.Models;

namespace MyExamsBackend.DTOs.ExamDTOs
{
    public class CreateExamRequestDTO
    {
        public string Name { get; set; }
        public int ProgrammingLanguageId { get; set; }
    }
}
