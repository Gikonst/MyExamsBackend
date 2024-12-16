using AutoMapper;
using MyExamsBackend.DTOs.AnswerDTOs;
using MyExamsBackend.DTOs.ExamDTOs;
using MyExamsBackend.Models;

namespace MyExamsBackend.Mappers.ExamMappers
{
    public class CreateExamMapper : Profile
    {
        public CreateExamMapper()
        { 
            CreateMap<CreateExamRequestDTO, Exam>();
        }
    }
}
