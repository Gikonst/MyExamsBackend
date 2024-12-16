using AutoMapper;
using MyExamsBackend.DTOs.ProgrammingLanguageDTOs;
using MyExamsBackend.Models;

namespace MyExamsBackend.Mappers.ProgrammingLanguageMappers
{
    public class UpdateProgrammingLanguageMapper : Profile
    {
        public UpdateProgrammingLanguageMapper()
        {
            CreateMap<UpdateProgrammingLanguageRequestDTO, ProgrammingLanguage>();
        }
    }
}
