using MyExamsBackend.DTOs.ProgrammingLanguageDTOs;
using MyExamsBackend.Models;

namespace MyExamsBackend.Services.Interfaces
{
    public interface IProgrammingLanguagesService
    {
        public Task<List<ProgrammingLanguageDTO>> GetAllAsync();
        public Task<ProgrammingLanguageDTO> GetByIdAsync(int id);
        public Task<bool> CreateAsync(ProgrammingLanguageRequestDTO createProgrammingLanguageRequestDto);
        public Task<bool> UpdateAsync(ProgrammingLanguageRequestDTO ProgrammingLanguageRequestDto);
        public Task<bool> DeleteAsync(int id);
    }
}

