using AutoMapper;
using MyExamsBackend.DTOs.CertificateDTOs;
using MyExamsBackend.Models;
using System.CodeDom;

namespace MyExamsBackend.Mappers.CertificateMappers
{
    public static class CertificateRequestMapper
    {

        public static Certificate MapForCreation(int examId, int userId)
        {
            return new Certificate
            {
                ExamId = examId,
                UserId = userId,
                Status = ExamStatusEnum.Passed,
                IssuedDate = DateTime.Now
            };
        }

        public static void MapUserExamRelationship(User user, Exam exam)
        {
            if (!user.Exams.Contains(exam))
            {
                user.Exams.Add(exam); // Automatically updates the UserExams table
            }
        }


    }
}
