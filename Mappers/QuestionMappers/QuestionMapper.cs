using MyExamsBackend.DTOs.QuestionDTOs;
using MyExamsBackend.Models;

namespace MyExamsBackend.Mappers.QuestionMappers
{
    public class QuestionMapper
    {
        public static Question MapToQuestion(QuestionRequestDTO dto)
        {
            return new Question
            {
                QuestionText = dto.QuestionText,
                Answers = new List<Answer>(),
                Exams = new List<Exam>()
            };
        }
    }
}
