using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyExamsBackend.Domain;
using MyExamsBackend.DTOs.ProgrammingLanguageDTOs;
using MyExamsBackend.Models;
using MyExamsBackend.Services.Interfaces;

namespace MyExamsBackend.Services
{
    public class ProgrammingLanguagesService : IProgrammingLanguagesService
    {
        private ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public ProgrammingLanguagesService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> CreateAsync(ProgrammingLanguageRequestDTO createProgrammingLanguageRequestDto)
        {
            var mappedObject = _mapper.Map<ProgrammingLanguage>(createProgrammingLanguageRequestDto);
            await _context.ProgrammingLanguages.AddAsync(mappedObject);
            var changed = await _context.SaveChangesAsync();

            return changed > 0;
        }

        public async Task <bool> DeleteAsync(int id)
        {
            var dbResult = await _context.ProgrammingLanguages.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (dbResult != null)
            { 
              _context.ProgrammingLanguages.Remove(dbResult);
              var DeleteResult = await _context.SaveChangesAsync();

              return DeleteResult > 0;             
            }
            return false;
        }

        public async Task<List<ProgrammingLanguageDTO>> GetAllAsync()
        {
            var dbResults = await _context.ProgrammingLanguages.ToListAsync();
            var mappedResults = _mapper.Map<List<ProgrammingLanguageDTO>>(dbResults);

            return mappedResults;
        }

        public async Task<ProgrammingLanguageDTO> GetByIdAsync(int id)
        {
            var dbResult = await _context.ProgrammingLanguages.Where(x => x.Id == id).FirstOrDefaultAsync();
            var mappedResult = _mapper.Map<ProgrammingLanguageDTO>(dbResult);

            return mappedResult;
        }

        public async Task<bool> UpdateAsync(ProgrammingLanguageRequestDTO ProgrammingLanguageRequestDto)
        {
            var dbObject = await _context.ProgrammingLanguages.AsNoTracking().Where(x => x.Id == ProgrammingLanguageRequestDto.Id).FirstOrDefaultAsync();
            if (dbObject != null)
            { 
                var mappedObject = _mapper.Map<ProgrammingLanguage>(ProgrammingLanguageRequestDto);
                _context.ProgrammingLanguages.Update(mappedObject);
                var SaveResults = await _context.SaveChangesAsync();
                return SaveResults > 0;
            }
            return false;

        }
    }
}
