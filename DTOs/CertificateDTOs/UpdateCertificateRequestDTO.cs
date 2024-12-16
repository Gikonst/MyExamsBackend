using MyExamsBackend.Models;

namespace MyExamsBackend.DTOs.CertificateDTOs
{
    public class UpdateCertificateRequestDTO
    {
        public int Id { get; set; }
        public ExamStatusEnum? Status { get; set; }
    }
}

