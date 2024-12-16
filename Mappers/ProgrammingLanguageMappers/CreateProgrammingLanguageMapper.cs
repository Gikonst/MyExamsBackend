using AutoMapper;
using MyExamsBackend.DTOs.ProgrammingLanguageDTOs;
using MyExamsBackend.Models;

namespace MyExamsBackend.Mappers.ProgrammingLanguageMappers
{
    public class CreateProgrammingLanguageMapper : Profile
    {
        public CreateProgrammingLanguageMapper()
        {
            CreateMap<CreateProgrammingLanguageRequestDTO, ProgrammingLanguage>();
        }
    }
}
