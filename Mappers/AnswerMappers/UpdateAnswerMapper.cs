using AutoMapper;
using MyExamsBackend.DTOs.AnswerDTOs;
using MyExamsBackend.Models;

namespace MyExamsBackend.Mappers.AnswerMapper
{
    public class UpdateAnswerMapper : Profile
    {
        public UpdateAnswerMapper()
        {
            CreateMap<UpdateAnswerRequestDTO, Answer>();
        }
    }
}
