using MyExamsBackend.Models;

namespace MyExamsBackend.DTOs.ExamDTOs
{
    public class UpdateExamRequestDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProgrammingLanguageId { get; set; }
    }
}
    

