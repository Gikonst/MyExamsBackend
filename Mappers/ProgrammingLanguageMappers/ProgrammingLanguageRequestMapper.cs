using AutoMapper;
using MyExamsBackend.DTOs.ProgrammingLanguageDTOs;
using MyExamsBackend.Models;

namespace MyExamsBackend.Mappers.ProgrammingLanguageMappers
{
    public class ProgrammingLanguageRequestMapper : Profile
    {
        public ProgrammingLanguageRequestMapper()
        {
            CreateMap<ProgrammingLanguageRequestDTO, ProgrammingLanguage>();
        }
    }
}
