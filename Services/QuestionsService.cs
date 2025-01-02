using Microsoft.EntityFrameworkCore;
using MyExamsBackend.Domain;
using MyExamsBackend.DTOs.AnswerDTOs;
using MyExamsBackend.DTOs.ExamDTOs;
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

        public List<QuestionResponseDTO> GetAll()
        {
            var dbResults = _context.Questions
                .Include(q => q.Answers)
                .Include(q => q.Exams)
                 .Select(q => new QuestionResponseDTO // Assuming you have a QuestionDTO to return
                 {
                     Id = q.Id,
                     QuestionText = q.QuestionText, 
                     Answers = q.Answers.Select(a => new AnswerResponseDTO
                     {
                         Id = a.Id,
                         AnswerText = a.AnswerText,
                         IsCorrect = a.IsCorrect,
                     }).ToList(),
                     Exams = q.Exams.Select(e => new ExamResponseQuestionDTO // Map the Exams to DTO
                     {
                         Id = e.Id,
                         Name = e.Name
                     }).ToList(),
                 })
                .ToList();
                
            return dbResults;
        }

        public Question GetById(int id)
        {
            var dbResult = _context.Questions.Where(x => x.Id == id).FirstOrDefault();

            return dbResult;
        }

        //TODO Make this one! Create DTO and Mapper
        public bool Update(UpdateQuestionRequestDTO questionDTO)
        {
            
            var dbObject = _context.Questions
                .Include(q => q.Exams) 
                .Include(q => q.Answers) 
                .FirstOrDefault(x => x.Id == questionDTO.Id);

            if (dbObject != null)
            {
                
                dbObject.QuestionText = questionDTO.QuestionText;

                
                var newExam = _context.Exams.Find(questionDTO.ExamId);
                if (newExam != null)
                {
                    
                    var existingExam = dbObject.Exams.FirstOrDefault(e => e.Id == newExam.Id);

                    if (existingExam == null)
                    {
                        
                        dbObject.Exams.Clear(); 
                        dbObject.Exams.Add(newExam); 
                    }
                   
                }
                else
                {
                    
                    return false; 
                }

                
                _context.SaveChanges();
                return true;
            }
            return false;
        }


    }
}
