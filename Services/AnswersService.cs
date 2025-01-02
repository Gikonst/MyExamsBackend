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

        
        public async Task<bool> CreateAsync(AnswerRequestDTO createAnswerRequestDto)
        {

            var mappedObject = _mapper.Map<Answer>(createAnswerRequestDto);
            await _context.Answers.AddAsync(mappedObject);
            var changed = await _context.SaveChangesAsync();

            return changed > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var dbResult = await _context.Answers.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (dbResult != null)
            {
                _context.Answers.Remove(dbResult);
                var deletedResult = await _context.SaveChangesAsync();

                return deletedResult > 0;
            }
            return false;
        }

        public async Task<List<AnswerResponseDTO>> GetAllAsync()
        {
            // Fetch answers with related questions from the database
            var dbResults = await _context.Answers
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
                .ToListAsync();

            return dbResults; // Return the results directly
        }


        public async Task<AnswerResponseDTO> GetByIdAsync(int id)
        {
            var dbResult = await _context.Answers.Where(x => x.Id == id).FirstOrDefaultAsync();
            var mappedResult = _mapper.Map<AnswerResponseDTO>(dbResult);

            return mappedResult;
        }

        public async Task<bool> UpdateAsync(AnswerRequestDTO updateAnswerRequestDto)
        {
            var dbObject = _context.Answers.AsNoTracking().Where(x => x.Id == updateAnswerRequestDto.Id).FirstOrDefaultAsync();

            if(dbObject != null)
            {
                var mappedResults = _mapper.Map<Answer>(updateAnswerRequestDto);
                 _context.Answers.Update(mappedResults);
                var saveResults = await _context.SaveChangesAsync();

                return saveResults > 0;
            }
            return false;
        } 
    }
}
