using Microsoft.EntityFrameworkCore;
using MyExamsBackend.Domain;
using MyExamsBackend.Models;
using MyExamsBackend.Services.Interfaces;

namespace MyExamsBackend.Services
{
    public class AnswersService : IAnswersService
    {
        private ApplicationDbContext _context;

        public AnswersService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Create(Answer answer)
        {
            _context.Answers.Add(answer);
            var changed = _context.SaveChanges();

            return changed > 0;
        }

        public bool Delete(int id)
        {
            var dbResult = _context.Answers.Where(x => x.Id == id).FirstOrDefault();
            if (dbResult != null)
            {
                _context.Answers.Remove(dbResult);
                var deletedResult = _context.SaveChanges();

                return deletedResult > 0;
            }
            return false;
        }

        public List<Answer> GetAll()
        {
            var dbResults = _context.Answers.ToList();
            return dbResults;
        }

        public Answer GetById(int id)
        {
            var dbResult = _context.Answers.Where(x => x.Id == id).FirstOrDefault();

            return dbResult;
        }

        public bool Update(Answer answer)
        {
            var dbObject = _context.Answers.AsNoTracking().Where(x => x.Id == answer.Id).FirstOrDefault();
            if(dbObject != null)
            {
                _context.Answers.Update(answer);
                var saveResults = _context.SaveChanges();

                return saveResults > 0;
            }
            return false;
        } 
    }
}
