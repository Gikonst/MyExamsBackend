using AutoMapper;
using MyExamsBackend.DTOs.ExamDTOs;
using MyExamsBackend.Models;

namespace MyExamsBackend.Mappers.ExamMappers
{
    public class UpdateExamMapper : Profile
    {
        public UpdateExamMapper()
        {
            CreateMap<UpdateExamRequestDTO, Exam>();
        }
    }
}
