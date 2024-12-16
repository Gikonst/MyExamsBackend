using MyExamsBackend.DTOs.ProgrammingLanguageDTOs;
using MyExamsBackend.Models;

namespace MyExamsBackend.Services.Interfaces
{
    public interface IProgrammingLanguagesService
    {
        public List<ProgrammingLanguageDTO> GetAll();
        public ProgrammingLanguageDTO GetById(int id);
        public bool Create(CreateProgrammingLanguageRequestDTO createProgrammingLanguageRequestDto);
        public bool Update(UpdateProgrammingLanguageRequestDTO updateProgrammingLanguageRequestDto);
        public bool Delete(int id);
    }
}

