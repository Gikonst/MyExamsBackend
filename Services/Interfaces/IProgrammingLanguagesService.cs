using MyExamsBackend.DTOs.ProgrammingLanguageDTOs;
using MyExamsBackend.Models;

namespace MyExamsBackend.Services.Interfaces
{
    public interface IProgrammingLanguagesService
    {
        public List<ProgrammingLanguageDTO> GetAll();
        public ProgrammingLanguageDTO GetById(int id);
        public bool Create(ProgrammingLanguageRequestDTO createProgrammingLanguageRequestDto);
        public bool Update(ProgrammingLanguageRequestDTO ProgrammingLanguageRequestDto);
        public bool Delete(int id);
    }
}

