using AutoMapper;
using MyExamsBackend.DTOs.AnswerDTOs;
using MyExamsBackend.Models;

namespace MyExamsBackend.Mappers.AnswerMapper
{
    public class AnswerMapper : Profile
    {
        public AnswerMapper()
        { 
            CreateMap<Answer, AnswerResponseDTO>();
        }
    }
}
