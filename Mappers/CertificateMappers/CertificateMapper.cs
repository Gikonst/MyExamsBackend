using AutoMapper;
using MyExamsBackend.DTOs.CertificateDTOs;
using MyExamsBackend.DTOs.ExamDTOs;
using MyExamsBackend.Models;

namespace MyExamsBackend.Mappers.CertificateMappers
{
    public static class CertificateMapper 
    {
        public static CertificateResponseDTO ToResponseDTO(Certificate certificate)
        {
            if (certificate == null)
                return null;

            return new CertificateResponseDTO
            {
                Id = certificate.Id,
                ExamId = certificate.ExamId,
                Exam = certificate.Exam != null ? new ExamResponseCertificateDTO
                {
                    Name = certificate.Exam.Name,
                    ImageSrc = certificate.Exam.ImageSrc,
                    Description = certificate.Exam.Description
                } : null,
                UserId = certificate.UserId,
                Score = certificate.Score ?? 0,
                Status = certificate.Status,
                IssuedDate = certificate.IssuedDate,
                EnrollmentDate = certificate.EnrollmentDate
            };
        }

        public static List<CertificateResponseDTO> ToResponseDTOList(List<Certificate> certificates)
        {
            return certificates?.Select(ToResponseDTO).ToList();
        }
    }
}
