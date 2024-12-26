using AutoMapper;
using MyExamsBackend.DTOs.CertificateDTOs;
using MyExamsBackend.Models;
using System.CodeDom;

namespace MyExamsBackend.Mappers.CertificateMappers
{
    public static class CertificateRequestMapper
    {

        public static Certificate MapForCreation(CertificateRequestDTO dto, int examId, int userId)
        {
            return new Certificate
            {
                ExamId = examId,
                UserId = userId,
                Status = ExamStatusEnum.Passed,
                IssuedDate = DateTime.Now
            };
        }


    }
}
