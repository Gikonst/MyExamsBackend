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

        public bool Create(CreateProgrammingLanguageRequestDTO createProgrammingLanguageRequestDto)
        {
            var mappedObject = _mapper.Map<ProgrammingLanguage>(createProgrammingLanguageRequestDto);
            _context.ProgrammingLanguages.Add(mappedObject);
            var changed = _context.SaveChanges();

            return changed > 0;
        }

        public bool Delete(int id)
        {
            var dbResult = _context.ProgrammingLanguages.Where(x => x.Id == id).FirstOrDefault();

            if (dbResult != null)
            { 
              _context.ProgrammingLanguages.Remove(dbResult);
              var DeleteResult = _context.SaveChanges();

              return DeleteResult > 0;             
            }
            return false;
        }

        public List<ProgrammingLanguageDTO> GetAll()
        {
            var dbResults = _context.ProgrammingLanguages.AsNoTracking().ToList();
            var mappedResults = _mapper.Map<List<ProgrammingLanguageDTO>>(dbResults);

            return mappedResults;
        }

        public ProgrammingLanguageDTO GetById(int id)
        {
            var dbResult = _context.ProgrammingLanguages.Include(p => p.Exams).AsNoTracking().Where(x => x.Id == id).FirstOrDefault();
            var mappedResult = _mapper.Map<ProgrammingLanguageDTO>(dbResult);

            return mappedResult;
        }

        public bool Update(UpdateProgrammingLanguageRequestDTO updateProgrammingLanguageRequestDto)
        {
            var dbObject = _context.ProgrammingLanguages.AsNoTracking().Where(x => x.Id == updateProgrammingLanguageRequestDto.Id).FirstOrDefault();
            if (dbObject != null)
            { 
                var mappedObject = _mapper.Map<ProgrammingLanguage>(updateProgrammingLanguageRequestDto);
                _context.ProgrammingLanguages.Update(mappedObject);
                var SaveResults = _context.SaveChanges();
                return SaveResults > 0;
            }
            return false;

        }
    }
}
