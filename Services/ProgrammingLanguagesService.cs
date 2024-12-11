using Microsoft.EntityFrameworkCore;
using MyExamsBackend.Domain;
using MyExamsBackend.Models;
using MyExamsBackend.Services.Interfaces;

namespace MyExamsBackend.Services
{
    public class ProgrammingLanguagesService : IProgrammingLanguagesService
    {
        private ApplicationDbContext _context;
        public ProgrammingLanguagesService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Create(ProgrammingLanguage programmingLanguage)
        {
            _context.ProgrammingLanguages.Add(programmingLanguage);
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

        public List<ProgrammingLanguage> GetAll()
        {
            var dbResults = _context.ProgrammingLanguages.ToList();

            return dbResults;
        }

        public ProgrammingLanguage GetById(int id)
        {
            var dbResult = _context.ProgrammingLanguages.Where(x => x.Id == id).FirstOrDefault();

            return dbResult;
        }

        public bool Update(ProgrammingLanguage programmingLanguage)
        {
            var dbObject = _context.ProgrammingLanguages.AsNoTracking().Where(x => x.Id == programmingLanguage.Id).FirstOrDefault();
            if (dbObject != null)
            { 
                _context.ProgrammingLanguages.Update(programmingLanguage);
                var SaveResults = _context.SaveChanges();
                return SaveResults > 0;
            }
            return false;

        }
    }
}
