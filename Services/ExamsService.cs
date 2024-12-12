using Microsoft.EntityFrameworkCore;
using MyExamsBackend.Domain;
using MyExamsBackend.Models;
using MyExamsBackend.Services.Interfaces;

namespace MyExamsBackend.Services
{
    public class ExamsService : IExamsService
    {
        private ApplicationDbContext _context;

        public ExamsService(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Create(Exam exam)
        {
            _context.Exams.Add(exam);
            var changed = _context.SaveChanges();

            return changed > 0;
        }

        public bool Delete(int id)
        {
            var dbResult = _context.Exams.Where(x => x.Id == id).FirstOrDefault();

            if(dbResult != null)
            {
                _context.Exams.Remove(dbResult);
                var deleteResult = _context.SaveChanges();

                return deleteResult > 0;
            }
            return false;
        }

        public List<Exam> GetAll()
        {
            var dbResults = _context.Exams.ToList();

            return dbResults;
        }

        public Exam GetById(int id)
        {
            var dbResult = _context.Exams.Where(x => x.Id == id).FirstOrDefault();

            return dbResult;
        }

        public bool Update(Exam exam) 
        {
            var dbObject = _context.Exams.AsNoTracking().Where(x => x.Id == exam.Id).FirstOrDefault();
            if(dbObject != null)
            {
                _context.Exams.Update(exam);
                var saveResults = _context.SaveChanges();
                return saveResults > 0;
            }
            return false;
        }
    }
}
