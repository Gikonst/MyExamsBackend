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


        public async Task<bool> DeleteAsync(int id)
        {
            var dbResult = await _context.Certificates.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (dbResult != null)
            {
                _context.Certificates.Remove(dbResult);
                var deleteResult = await _context.SaveChangesAsync();

                return deleteResult > 0;
            }
            return false;
        }

        public async Task<List<CertificateResponseDTO>> GetAllAsync()
        {
            var dbResults = await _context.Certificates
                .Include(c => c.Exam)
                .ToListAsync();
            var mappedResults = CertificateMapper.ToResponseDTOList(dbResults);

            return mappedResults;
        }

        
        public async Task<List<CertificateResponseDTO>> GetByUserIdAsync(int id)
        {
            var dbResult = await _context.Certificates.Where(x => x.UserId == id)
                .Include(c => c.Exam)
                .ToListAsync();

            var mappedResults = CertificateMapper.ToResponseDTOList(dbResult);

            return mappedResults;
        }


        public async Task<byte[]> GenerateCertificateAsync(int certificateId)
        {
            var certificate = await _context.Certificates
                .Include(c => c.User)
                .Include(c => c.Exam)
                .FirstOrDefaultAsync(c => c.Id == certificateId && c.IssuedDate != null);

            if (certificate == null)
                throw new ArgumentException("Invalid certificate ID or certificate has not been issued.");

            var userFullName = $"{certificate.User.FirstName} {certificate.User.LastName}";
            var examName = certificate.Exam.Name;
            var description = certificate.Exam.Description;
            var issuedDate = certificate.IssuedDate.ToString("dd-MM-yyyy") ?? "N/A";

            string template = await System.IO.File.ReadAllTextAsync("CertificateTemplate.html");
            string htmlContent = template.Replace("{{Name}}", userFullName)
                                         .Replace("{{ExamName}}", examName)
                                         .Replace("{{Description}}", description)
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
            byte[] pdfBytes = await Task.Run(() => _converter.Convert(pdfDocument));
            return pdfBytes;
        }

        public async Task<bool> CreateAsync(int examId, int userId)
        {
            bool certificateExists = await _context.Certificates
                .AnyAsync(c => c.UserId == userId && c.ExamId == examId);

            if (certificateExists)
            {
                return false;
            }

            var user = await _context.Users.Include(u => u.Exams).FirstOrDefaultAsync(u => u.Id == userId);
            var exam = await _context.Exams.Include(e => e.Users).FirstOrDefaultAsync(e => e.Id == examId);

            if (user == null || exam == null)
            {
                return false;
            }

            var mappedObject = CertificateRequestMapper.MapForCreation(examId, userId);
            CertificateRequestMapper.MapUserExamRelationship(user,exam);

            await _context.Certificates.AddAsync(mappedObject);
            var changed = await _context.SaveChangesAsync();

            return changed > 0;
        }

   
    }
}

