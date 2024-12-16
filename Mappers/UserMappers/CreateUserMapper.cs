using AutoMapper;
using MyExamsBackend.DTOs.UserDTOs;
using MyExamsBackend.Models;

namespace MyExamsBackend.Mappers.UserMappers
{
    public class CreateUserMapper : Profile
    {
        public CreateUserMapper()
        {
            CreateMap<CreateUserRequestDTO, User>();
        }
        
    }
}
