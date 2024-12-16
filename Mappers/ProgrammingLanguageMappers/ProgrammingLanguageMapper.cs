using AutoMapper;
using MyExamsBackend.DTOs.ProgrammingLanguageDTOs;
using MyExamsBackend.Models;

namespace MyExamsBackend.Mappers.ProgrammingLanguageMappers
{
    public class ProgrammingLanguageMapper : Profile
    {
        public ProgrammingLanguageMapper()
        {
            CreateMap<ProgrammingLanguage, ProgrammingLanguageDTO>();
        }
    }
}
