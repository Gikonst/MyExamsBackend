using MyExamsBackend.Models;

namespace MyExamsBackend.DTOs.CertificateDTOs
{
    public class CreateCertificateRequestDTO
    { 
        public int Id { get; set; }
        public int ExamId { get; set; }
        public int UserId { get; set; }
        public ExamStatusEnum Status { get; set; }
        public DateTime IssuedDate { get; set; }
    }

}

