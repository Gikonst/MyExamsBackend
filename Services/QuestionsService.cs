using Microsoft.EntityFrameworkCore;
using MyExamsBackend.Domain;
using MyExamsBackend.DTOs.QuestionDTOs;
using MyExamsBackend.Models;
using MyExamsBackend.Services.Interfaces;

namespace MyExamsBackend.Services
{
    public class QuestionsService : IQuestionsService
    {
        private ApplicationDbContext _context;
        public QuestionsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Create(QuestionRequestDTO newQuestion)
        {
            var question = new Question
            {
                QuestionText = newQuestion.QuestionText,
                Answers = new List<Answer>(),
                Exams = new List<Exam>()
            };
            _context.Questions.Add(question);
            var changed = _context.SaveChanges();

            return changed > 0;
        }

        public bool Delete(int id)
        {
            var dbResult = _context.Questions.Where(x => x.Id == id).FirstOrDefault();

            if (dbResult != null)
            {
                _context.Questions.Remove(dbResult);
                var DeleteResult = _context.SaveChanges();

                return DeleteResult > 0;
            }
            return false;
        }

        public List<Question> GetAll()
        {
            var dbResults = _context.Questions.Include(q => q.Answers).ToList();

            return dbResults;
        }

        public Question GetById(int id)
        {
            var dbResult = _context.Questions.Where(x => x.Id == id).FirstOrDefault();

            return dbResult;
        }

        public bool Update(Question question)
        {
            var dbObject = _context.Questions.AsNoTracking().Where(x => x.Id == question.Id).FirstOrDefault();
            if (dbObject != null)
            {
                _context.Questions.Update(question);
                var SaveResults = _context.SaveChanges();
                return SaveResults > 0;
            }
            return false;

        }
    }
}
