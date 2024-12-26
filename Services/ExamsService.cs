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

        public (double Score, bool Passed) CalculateScore(int examId, List<TestUserAnswersDTO> userAnswers)
        {
            var questions = _context.Questions
           .Include(q => q.Answers)
           .Where(q => q.Exams.Any(e => e.Id == examId))
           .ToList();

            int totalQuestions = questions.Count;
            int correctAnswersCount = 0;

            foreach (var userAnswer in userAnswers)
            {
                var question = questions.FirstOrDefault(q => q.Id == userAnswer.QuestionId);
                if (question != null)
                {
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

        public bool Create(CreateExamRequestDTO createExamRequestDto)
        {
            var mappedObject = _mapper.Map<Exam>(createExamRequestDto);
            _context.Exams.Add(mappedObject);
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

        public List<ExamResponseDTO> GetAll()
        {
            var dbResults = _context.Exams
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
                .ToList();

            return dbResults;
        }

        public ExamResponseDTO GetById(int id)
        {
            var dbResult = _context.Exams
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
                .FirstOrDefault();

            return dbResult;
        }

        public bool Update(UpdateExamRequestDTO updateExamRequestDto)
        {
            // Fetch the existing exam from the database
            var existingExam = _context.Exams
                .Include(e => e.Certificates)
                .Include(e => e.Questions)
                .Include(e => e.Users)
                .FirstOrDefault(x => x.Id == updateExamRequestDto.Id);

            if (existingExam == null)
            {
                return false; // Exam not found
            }

            
            UpdateExamMapper.MapForUpdate(updateExamRequestDto, existingExam);

            
            try
            {
                _context.Exams.Update(existingExam);
                var saveResults = _context.SaveChanges();
                return saveResults > 0; 
            }
            catch (Exception ex)
            {
                
                return false;
            }
        }
    }
}
