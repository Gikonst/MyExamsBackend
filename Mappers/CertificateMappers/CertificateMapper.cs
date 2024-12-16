using AutoMapper;
using MyExamsBackend.DTOs.CertificateDTOs;
using MyExamsBackend.Models;

namespace MyExamsBackend.Mappers.CertificateMappers
{
    public class CertificateMapper : Profile
    {
        public CertificateMapper()
        {
            CreateMap<Certificate, CertificateResponseDTO>();
        }
    }
}
