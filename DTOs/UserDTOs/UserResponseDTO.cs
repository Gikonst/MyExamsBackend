using MyExamsBackend.DTOs.CertificateDTOs;
using MyExamsBackend.DTOs.ExamDTOs;
using MyExamsBackend.Models;

namespace MyExamsBackend.DTOs.UserDTOs
{
    public class UserResponseDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<CertificateResponseDTO> EnrolledExams { get; set; }
        public List<CertificateResponseDTO> PassedCertificates { get; set; }
        public UserResponseDTO()
        {
            EnrolledExams = new List<CertificateResponseDTO>();
            PassedCertificates = new List<CertificateResponseDTO>();
        }
    }
}
