using AutoMapper;
using MyExamsBackend.DTOs.ExamDTOs;
using MyExamsBackend.Models;

namespace MyExamsBackend.Mappers.ExamMappers
{
    public class ExamMapper : Profile
    {
        public ExamMapper()
        {
            CreateMap<Exam, ExamResponseDTO>();
        }
    }
}
