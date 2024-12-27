using AutoMapper;
using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.EntityFrameworkCore;
using MyExamsBackend.Domain;
using MyExamsBackend.DTOs.AnswerDTOs;
using MyExamsBackend.DTOs.CertificateDTOs;
using MyExamsBackend.DTOs.ExamDTOs;
using MyExamsBackend.Mappers.CertificateMappers;
using MyExamsBackend.Models;
using MyExamsBackend.Services.Interfaces;

namespace MyExamsBackend.Services
{
    public class CertificatesService : ICertificatesService
    {
        private ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IConverter _converter;
        public CertificatesService(ApplicationDbContext context, IMapper mapper, IConverter converter)
        {
            _context = context;
            _mapper = mapper;
            _converter = converter;
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

        
        public List<CertificateResponseDTO> GetByUserId(int id)
        {
            var dbResult = _context.Certificates.Where(x => x.UserId == id)
                .Include(c => c.Exam)
                .ToList();

            var mappedResults = CertificateMapper.ToResponseDTOList(dbResult);

            return mappedResults;
        }


        public byte[] GenerateCertificate(int certificateId)
        {
            var certificate = _context.Certificates
                .Include(c => c.User)
                .Include(c => c.Exam)
                .FirstOrDefault(c => c.Id == certificateId && c.IssuedDate != null);

            if (certificate == null)
                throw new ArgumentException("Invalid certificate ID or certificate has not been issued.");

            var userFullName = $"{certificate.User.FirstName} {certificate.User.LastName}";
            var examName = certificate.Exam.Name;
            var issuedDate = certificate.IssuedDate.ToString("dd-MM-yyyy") ?? "N/A";

            string template = System.IO.File.ReadAllText("CertificateTemplate.html");
            string htmlContent = template.Replace("{{Name}}", userFullName)
                                         .Replace("{{ExamName}}", examName)
                                         .Replace("{{IssuedDate}}", issuedDate);

            var pdfDocument = new HtmlToPdfDocument()
            {
                GlobalSettings = new GlobalSettings
                {
                    ColorMode = ColorMode.Color,
                    Orientation = Orientation.Portrait,
                    PaperSize = PaperKind.A4,
                    Margins = new MarginSettings { Top = 10, Bottom = 10 },
                },
                Objects = { new ObjectSettings { HtmlContent = htmlContent } }
            };

            return _converter.Convert(pdfDocument);
        }

        public bool Create(CertificateRequestDTO createCertificateRequestDto, int examId, int userId)
        {
            bool certificateExists = _context.Certificates
                .Any(c => c.UserId == userId && c.ExamId == examId);

            if (certificateExists)
            {
                return false;
            }

            var mappedObject = CertificateRequestMapper.MapForCreation(createCertificateRequestDto, examId, userId);
            _context.Certificates.Add(mappedObject);
            var changed = _context.SaveChanges();

            return changed > 0;
        }

   
    }
}

