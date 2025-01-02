using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using MyExamsBackend.Domain;
using MyExamsBackend.DTOs.AnswerDTOs;
using MyExamsBackend.DTOs.QuestionDTOs;
using MyExamsBackend.Models;
using MyExamsBackend.Services.Interfaces;

namespace MyExamsBackend.Services
{
    public class AnswersService : IAnswersService
    {
        private ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public AnswersService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //TODO Needs DTO and mapper
        public bool Create(AnswerRequestDTO createAnswerRequestDto)
        {

            var mappedObject = _mapper.Map<Answer>(createAnswerRequestDto);
            _context.Answers.Add(mappedObject);
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

        public List<AnswerResponseDTO> GetAll()
        {
            // Fetch answers with related questions from the database
            var dbResults = _context.Answers
                .Include(a => a.Question) // Eagerly load the related Question
                .Select(a => new AnswerResponseDTO
                {
                    Id = a.Id,
                    AnswerText = a.AnswerText,
                    IsCorrect = a.IsCorrect,
                    Question = a.Question != null
                        ? new QuestionResponseAnswerDTO
                        {
                            Id = a.Question.Id,
                            QuestionText = a.Question.QuestionText
                        }
                        : null
                })
                .ToList();

            return dbResults; // Return the results directly
        }


        public AnswerResponseDTO GetById(int id)
        {
            var dbResult = _context.Answers.Where(x => x.Id == id).FirstOrDefault();
            var mappedResult = _mapper.Map<AnswerResponseDTO>(dbResult);

            return mappedResult;
        }

        public bool Update(AnswerRequestDTO updateAnswerRequestDto)
        {
            var dbObject = _context.Answers.AsNoTracking().Where(x => x.Id == updateAnswerRequestDto.Id).FirstOrDefault();

            if(dbObject != null)
            {
                var mappedResults = _mapper.Map<Answer>(updateAnswerRequestDto);
                _context.Answers.Update(mappedResults);
                var saveResults = _context.SaveChanges();

                return saveResults > 0;
            }
            return false;
        } 
    }
}
