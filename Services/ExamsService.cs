using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyExamsBackend.Domain;
using MyExamsBackend.DTOs.ExamDTOs;
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
            var dbResults = _context.Exams.Include(e => e.ProgrammingLanguage).Include(e => e.Questions).ToList();
            var mappedResults = _mapper.Map<List<ExamResponseDTO>>(dbResults);
            return mappedResults;
        }

        public ExamResponseDTO GetById(int id)
        {
            var dbResult = _context.Exams.Where(x => x.Id == id).Include(e => e.ProgrammingLanguage).Include(e => e.Questions).FirstOrDefault();
            var mappedResult = _mapper.Map<ExamResponseDTO>(dbResult);
            return mappedResult;
        }

        public bool Update(UpdateExamRequestDTO updateExamRequestDto) 
        {
            var dbObject = _context.Exams.AsNoTracking().Where(x => x.Id == updateExamRequestDto.Id).FirstOrDefault();
            if(dbObject != null)
            {
                var mappedObject = _mapper.Map<Exam>(updateExamRequestDto);
                _context.Exams.Update(mappedObject);
                var saveResults = _context.SaveChanges();
                return saveResults > 0;
            }
            return false;
        }
    }
}
