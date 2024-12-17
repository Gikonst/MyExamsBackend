using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyExamsBackend.Domain;
using MyExamsBackend.DTOs.AnswerDTOs;
using MyExamsBackend.DTOs.CertificateDTOs;
using MyExamsBackend.Models;
using MyExamsBackend.Services.Interfaces;

namespace MyExamsBackend.Services
{
    public class CertificatesService : ICertificatesService
    {
        private ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public CertificatesService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        //Creating an enrollment certificate
        public bool Enroll(CertificateRequestDTO createCertificateRequestDto)
        {
            createCertificateRequestDto = new CertificateRequestDTO()
            {
                ExamId = createCertificateRequestDto.ExamId,
                UserId = createCertificateRequestDto.UserId,
                Score = createCertificateRequestDto.Score,
                Status = 0,
                EnrollmentDate = createCertificateRequestDto.EnrollmentDate,
                IssuedDate = null
            };
            var mappedObject = _mapper.Map<Certificate>(createCertificateRequestDto);
            _context.Certificates.Add(mappedObject);
            var changed = _context.SaveChanges();

            return changed > 0;
        }

        public bool FinalizeCertificate(CertificateRequestDTO certificateRequestDTO)
        {
            var dbObject = _context.Certificates.AsNoTracking().Where(x => x.Id == certificateRequestDTO.Id).FirstOrDefault();

            if (dbObject != null)
            {
                dbObject.Score = certificateRequestDTO.Score;
                dbObject.IssuedDate = certificateRequestDTO.IssuedDate.Value;

                _context.Certificates.Update(dbObject);
                var saveResults = _context.SaveChanges();

                return saveResults > 0;
            }
            return false;
        }

        public bool Delete(int id)
        {
            var dbResult = _context.Certificates.Where(x => x.Id == id).FirstOrDefault();

            if (dbResult != null)
            {
                _context.Certificates.Remove(dbResult);
                var deleteResult = _context.SaveChanges();
                
                return deleteResult > 0;
            }
            return false;
        }

        public List<CertificateResponseDTO> GetAll()
        {
            var dbResults = _context.Certificates.ToList();
            var mappedResults = _mapper.Map<List<CertificateResponseDTO>>(dbResults);

            return mappedResults;
        }

        // Get Certificate by userID exam obj included
        public List<CertificateResponseDTO> GetByUserId(int id)
        {
            var dbResult = _context.Certificates.Where(x => x.UserId == id).Include(c => c.Exam).ToList();
            var mappedResults = _mapper.Map<List<CertificateResponseDTO>>(dbResult);

            return mappedResults;
        }

    
        public bool Update(CertificateRequestDTO certificateRequestDto)
        {
            var dbObject = _context.Certificates.AsNoTracking().Where(x => x.Id == certificateRequestDto.Id).FirstOrDefault();

            if (dbObject != null)
            {
                var mappedObject = _mapper.Map<Certificate>(certificateRequestDto);

                _context.Certificates.Update(mappedObject);
                var saveResults = _context.SaveChanges();

                return saveResults > 0;
            }
            return false;
        }
    }
}
