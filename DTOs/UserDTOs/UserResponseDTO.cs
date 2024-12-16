using MyExamsBackend.DTOs.CertificateDTOs;
using MyExamsBackend.DTOs.ExamDTOs;
using MyExamsBackend.Models;

namespace MyExamsBackend.DTOs.UserDTOs
{
    public class UserResponseDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public UserRoleType Role { get; set; }
        public List<ExamResponseDTO> Exams { get; set; }
        public List<CertificateResponseDTO> Certificates { get; set; }
        public UserResponseDTO()
        {
            Exams = new List<ExamResponseDTO>();
            Certificates = new List<CertificateResponseDTO>();
        }
    }
}
