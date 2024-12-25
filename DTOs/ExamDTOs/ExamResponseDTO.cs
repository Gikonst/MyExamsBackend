using MyExamsBackend.DTOs.QuestionDTOs;
using MyExamsBackend.DTOs.UserDTOs;
using MyExamsBackend.Models;

namespace MyExamsBackend.DTOs.ExamDTOs
{
    public class ExamResponseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProgrammingLanguageId { get; set; }
        public string ImageSrc { get; set; }
        public string Description { get; set; }
        public List<QuestionResponseDTO> Questions { get; set; }

        public ExamResponseDTO()
        {
            Questions = new List<QuestionResponseDTO>();
        }
    }
}
