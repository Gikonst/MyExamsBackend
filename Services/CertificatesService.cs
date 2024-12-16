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
        
        public bool Create(CreateCertificateRequestDTO createCertificateRequestDto)
        {
            var mappedObject = _mapper.Map<Certificate>(createCertificateRequestDto);
            _context.Certificates.Add(mappedObject);
            var changed = _context.SaveChanges();

            return changed > 0;
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

        public CertificateResponseDTO GetById(int id)
        {
            var dbResult = _context.Certificates.Where(x => x.Id == id).FirstOrDefault();
            var mappedResults = _mapper.Map<CertificateResponseDTO>(dbResult);

            return mappedResults;
        }

        public bool Update(UpdateCertificateRequestDTO updateCertificateRequestDto)
        {
            var dbObject = _context.Certificates.AsNoTracking().Where(x => x.Id == updateCertificateRequestDto.Id).FirstOrDefault();

            if (dbObject != null)
            {
                var mappedResults = _mapper.Map<Certificate>(updateCertificateRequestDto);
                _context.Certificates.Update(mappedResults);
                var saveResults = _context.SaveChanges();

                return saveResults > 0;
            }
            return false;
        }
    }
}
