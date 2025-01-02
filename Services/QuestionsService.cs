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

        public async Task<bool> CreateAsync(QuestionRequestDTO newQuestion)
        {
            
            var exam = await _context.Exams.FirstOrDefaultAsync(e => e.Id == newQuestion.ExamId);

            if (exam == null)
            {
                
                return false;
            }

            var question = QuestionMapper.MapToQuestion(newQuestion);

            question.Exams.Add(exam);

            // Add the question to the context
            await _context.Questions.AddAsync(question);

            // Save changes to populate the ExamQuestion table
            var changed = await _context.SaveChangesAsync();

            return changed > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var dbResult = await _context.Questions.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (dbResult != null)
            {
                _context.Questions.Remove(dbResult);
                var DeleteResult = await _context.SaveChangesAsync();

                return DeleteResult > 0;
            }
            return false;
        }

        public async Task<List<QuestionResponseDTO>> GetAllAsync()
        {
            var dbResults = await _context.Questions
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
                .ToListAsync();
                
            return dbResults;
        }

        public async Task<Question> GetByIdAsync(int id)
        {
            var dbResult = await _context.Questions.Where(x => x.Id == id).FirstOrDefaultAsync();

            return dbResult;
        }

        
        public async Task<bool> UpdateAsync(UpdateQuestionRequestDTO questionDTO)
        {
            
            var dbObject = await _context.Questions
                .Include(q => q.Exams) 
                .Include(q => q.Answers) 
                .FirstOrDefaultAsync(x => x.Id == questionDTO.Id);

            if (dbObject != null)
            {
                
                dbObject.QuestionText = questionDTO.QuestionText;

                
                var newExam = await _context.Exams.FindAsync(questionDTO.ExamId);
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
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }


    }
}
