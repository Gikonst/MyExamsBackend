﻿using MyExamsBackend.DTOs.ExamDTOs;
using MyExamsBackend.Models;

namespace MyExamsBackend.DTOs.CertificateDTOs
{
    public class CertificateResponseUserDTO
    {
        public int Id { get; set; }
        public int ExamId { get; set; }
        public ExamResponseCertificateDTO? Exam { get; set; }
        public int UserId { get; set; }
        public int Score { get; set; }
        public ExamStatusEnum? Status { get; set; }
        public DateTime? IssuedDate { get; set; }
        public DateTime EnrollmentDate { get; set;}
    }

}