using MyExamsBackend.DTOs.CertificateDTOs;
using MyExamsBackend.Models;

namespace MyExamsBackend.Services.Interfaces
{
    public interface ICertificatesService
    {
        public Task<List<CertificateResponseDTO>> GetAllAsync();
        public Task<List<CertificateResponseDTO>> GetByUserIdAsync(int id);
        public Task<byte[]> GenerateCertificateAsync(int certificateId);
        public Task<bool> CreateAsync(int examId, int userId);
        public Task<bool> DeleteAsync(int id);
    }
}
