using MyExamsBackend.Models;

namespace MyExamsBackend.DTOs.AnswerDTOs
{
    //For the GETs
    public class AnswerResponseDTO
    {
        public int Id { get; set; }
        public string AnswerText { get; set; }
        public bool IsCorrect { get; set; }
    }
}
