using AutoMapper;
using MyExamsBackend.DTOs.UserDTOs;
using MyExamsBackend.Models;

namespace MyExamsBackend.Mappers.UserMappers
{
    public class UpdateUserMapper : Profile
    {
        public UpdateUserMapper()
        {
            CreateMap<UpdateUserRequestDTO, User>();
        }
    }
}
