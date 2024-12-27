using Microsoft.EntityFrameworkCore;
using MyExamsBackend.Domain;
using MyExamsBackend.DTOs.QuestionDTOs;
using MyExamsBackend.Mappers.QuestionMappers;
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
            // Find the related exam
            var exam = _context.Exams.FirstOrDefault(e => e.Id == newQuestion.ExamId);

            if (exam == null)
            {
                // If the exam doesn't exist, return false or handle the error
                return false;
            }

            // Use the mapper to create a Question object
            var question = QuestionMapper.MapToQuestion(newQuestion);

            // Associate the question with the exam
            question.Exams.Add(exam);

            // Add the question to the context
            _context.Questions.Add(question);

            // Save changes to populate the ExamQuestion table
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

        //TODO Make this one! Create DTO and Mapper
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
