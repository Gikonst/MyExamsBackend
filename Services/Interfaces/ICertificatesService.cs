using MyExamsBackend.DTOs.CertificateDTOs;
using MyExamsBackend.Models;

namespace MyExamsBackend.Services.Interfaces
{
    public interface ICertificatesService
    {
        public List<CertificateResponseDTO> GetAll();
        public List<CertificateResponseDTO> GetByUserId(int id);
        public byte[] GenerateCertificate(int certificateId);
        public bool Enroll(CertificateRequestDTO createCertificateRequestDto);
        public bool FinalizeCertificate(CertificateRequestDTO createCertificateRequestDto);
        public bool Update(CertificateRequestDTO certificateRequestDTO);
        public bool Delete(int id);
    }
}
