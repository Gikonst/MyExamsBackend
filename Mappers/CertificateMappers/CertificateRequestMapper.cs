using AutoMapper;
using MyExamsBackend.DTOs.CertificateDTOs;
using MyExamsBackend.Models;
using System.CodeDom;

namespace MyExamsBackend.Mappers.CertificateMappers
{
    public static class CertificateRequestMapper
    {
        public static Certificate MapForEnrollment(CertificateRequestDTO dto)
        {
            return new Certificate
            {
                ExamId = dto.ExamId,
                UserId = dto.UserId,
                Score = 0,
                Status = ExamStatusEnum.Enrolled, 
                EnrollmentDate = DateTime.Now,
                IssuedDate = null 
            };
        }

        public static Certificate UpdateForFinalize(Certificate certificate, CertificateRequestDTO dto)
        {
            certificate.Score = dto.Score;
            certificate.Status = ExamStatusEnum.Passed;
            certificate.IssuedDate = dto.IssuedDate ?? certificate.IssuedDate;

            return certificate;
        }

        public static Certificate MapForCreation(CertificateRequestDTO dto)
        {
            return new Certificate
            {
                ExamId = dto.ExamId,
                UserId = dto.UserId,
                Score = dto.Score,
                Status = ExamStatusEnum.Passed,
                EnrollmentDate = DateTime.Now,
                IssuedDate = dto.IssuedDate ?? DateTime.Now
            };
        }


    }
}
