using AutoMapper;
using MyExamsBackend.DTOs.AnswerDTOs;
using MyExamsBackend.Models;

namespace MyExamsBackend.Mappers.AnswerMapper
{
    public class CreateAnswerMapper : Profile
    {
        public CreateAnswerMapper()
        {
            CreateMap<AnswerRequestDTO, Answer>();
        }
    }
}