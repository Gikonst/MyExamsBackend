using AutoMapper;
using MyExamsBackend.DTOs.CertificateDTOs;
using MyExamsBackend.Models;

namespace MyExamsBackend.Mappers.CertificateMappers
{
    public class UpdateCertificateMapper : Profile
    {
        public UpdateCertificateMapper() => CreateMap<UpdateCertificateRequestDTO, Certificate>();
    }
}
