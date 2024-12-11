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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
