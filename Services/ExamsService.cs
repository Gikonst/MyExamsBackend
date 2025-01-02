using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyExamsBackend.Domain;
using MyExamsBackend.DTOs.AnswerDTOs;
using MyExamsBackend.DTOs.ExamDTOs;
using MyExamsBackend.DTOs.QuestionDTOs;
using MyExamsBackend.DTOs.TestDTOs;
using MyExamsBackend.Mappers.ExamMappers;
using MyExamsBackend.Models;
using MyExamsBackend.Services.Interfaces;

namespace MyExamsBackend.Services
{
    public class ExamsService : IExamsService
    {
        private ApplicationDbContext _context;
        private IMapper _mapper;

        public ExamsService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;   
        }

        public async Task<(double Score, bool Passed)> CalculateScoreAsync(int examId, List<TestUserAnswersDTO> userAnswers)
        {
            var questions = await _context.Questions
           .Include(q => q.Answers)
           .Where(q => q.Exams.Any(e => e.Id == examId))
           .ToListAsync();

            int totalQuestions = questions.Count;
            int correctAnswersCount = 0;

            var questionDictionary = questions.ToDictionary(q => q.Id);

            foreach (var userAnswer in userAnswers)
            {
                if (questionDictionary.TryGetValue(userAnswer.QuestionId, out var question))
                {
                    // Find the selected answer in the question's answers
                    var selectedAnswer = question.Answers.FirstOrDefault(a => a.Id == userAnswer.SelectedAnswerId);
                    if (selectedAnswer != null && selectedAnswer.IsCorrect)
                    {
                        correctAnswersCount++;
                    }
                }
            }
            double score = ((double)correctAnswersCount / totalQuestions) * 100;

            bool passed = score >= 50 ;

            return (score, passed);
        }

        public async Task<bool> CreateAsync(CreateExamRequestDTO createExamRequestDto)
        {

            try
            {
                // Map DTO to Exam
                var newExam = CreateExamMapper.MapForExamCreate(createExamRequestDto);

                // Add new Exam to the context
                await _context.Exams.AddAsync(newExam);

                // Save changes to the database
                var saveResult = await _context.SaveChangesAsync();
                return saveResult > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var dbResult = await _context.Exams.Where(x => x.Id == id).FirstOrDefaultAsync();

            if(dbResult != null)
            {
                _context.Exams.Remove(dbResult);
                var deleteResult = await _context.SaveChangesAsync();

                return deleteResult > 0;
            }
            return false;
        }

        public async Task<List<ExamResponseDTO>> GetAllAsync()
        {
            var dbResults = await _context.Exams
                .Include(e => e.Questions)
                .ThenInclude(q => q.Answers)
                .Select(e => new ExamResponseDTO
                {
                    Id = e.Id,
                    Name = e.Name,
                    ProgrammingLanguageId = e.ProgrammingLanguageId,
                    ImageSrc = e.ImageSrc,
                    Description = e.Description,
                    Questions = e.Questions.Select(q => new QuestionResponseDTO
                    {
                        Id = q.Id,
                        QuestionText = q.QuestionText,
                        Answers = q.Answers.Select(a => new AnswerResponseDTO
                        {
                            Id = a.Id,
                            AnswerText = a.AnswerText,
                            IsCorrect = a.IsCorrect,
                        }).ToList()
                    }).ToList()
                })
                .ToListAsync();

            return dbResults;
        }

        public async Task<ExamResponseDTO> GetByIdAsync(int id)
        {
            var dbResult = await _context.Exams
                .Where(x => x.Id == id)
                .Include(e => e.Questions)
                .ThenInclude(q => q.Answers)
                .Select(e => new ExamResponseDTO
                {
                    Id = e.Id,
                    Name = e.Name,
                    ProgrammingLanguageId = e.ProgrammingLanguageId,
                    ImageSrc = e.ImageSrc,
                    Description = e.Description,
                    Questions = e.Questions.Select(q => new QuestionResponseDTO
                    {
                        Id = q.Id,
                        QuestionText = q.QuestionText,
                        Answers = q.Answers.Select(a => new AnswerResponseDTO
                        {
                            Id = a.Id,
                            AnswerText = a.AnswerText,
                            IsCorrect = a.IsCorrect,
                        }).ToList()
                    }).ToList()
                })
                .FirstOrDefaultAsync();

            return dbResult;
        }

        public async Task<bool> UpdateAsync(UpdateExamRequestDTO updateExamRequestDto)
        {
            // Fetch the existing exam from the database
            var existingExam = await _context.Exams
                .Include(e => e.Certificates)
                .Include(e => e.Questions)
                .Include(e => e.Users)
                .FirstOrDefaultAsync(x => x.Id == updateExamRequestDto.Id);

            if (existingExam == null)
            {
                return false; // Exam not found
            }

            
            UpdateExamMapper.MapForUpdate(updateExamRequestDto, existingExam);

            
            try
            {
                _context.Exams.Update(existingExam);
                var saveResults = await _context.SaveChangesAsync();
                return saveResults > 0; 
            }
            catch (Exception ex)
            {
                
                return false;
            }
        }
    }
}
