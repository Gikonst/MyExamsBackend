using AutoMapper;
using MyExamsBackend.DTOs.AnswerDTOs;
using MyExamsBackend.DTOs.ExamDTOs;
using MyExamsBackend.Models;

namespace MyExamsBackend.Mappers.ExamMappers
{
    public static class CreateExamMapper 
    {
        public static Exam MapForExamCreate(CreateExamRequestDTO dto)
        {
            return new Exam
            {
                Name = dto.Name,
                ImageSrc = dto.ImageSrc,
                Description = dto.Description,
                ProgrammingLanguageId = dto.ProgrammingLanguageId
            };
            
        }
    }
}
