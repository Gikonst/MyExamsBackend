using MyExamsBackend.Models;

namespace MyExamsBackend.DTOs.CertificateDTOs
{
    public class CertificateResponseDTO
    {
        public int Id { get; set; }
        public int ExamId { get; set; }
        public int UserId { get; set; }
        // public int UserDto UserDto {get; set}
        public ExamStatusEnum? Status { get; set; }
        public DateTime? IssuedDate { get; set; }
    }

}
