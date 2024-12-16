using MyExamsBackend.DTOs.CertificateDTOs;
using MyExamsBackend.Models;

namespace MyExamsBackend.Services.Interfaces
{
    public interface ICertificatesService
    {
        public List<CertificateResponseDTO> GetAll();
        public CertificateResponseDTO GetById(int id);
        public bool Create(CreateCertificateRequestDTO createCertificateRequestDto);
        public bool Update(UpdateCertificateRequestDTO updateCertificateRequestDto);
        public bool Delete(int id);
    }
}
