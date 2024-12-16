using AutoMapper;
using MyExamsBackend.DTOs.CertificateDTOs;
using MyExamsBackend.Models;
using System.CodeDom;

namespace MyExamsBackend.Mappers.CertificateMappers
{
    public class CreateCertificateMapper : Profile
    {
        public CreateCertificateMapper()
        {
            CreateMap<CreateCertificateRequestDTO, Certificate>();
        }
    }
}
