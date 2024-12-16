using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyExamsBackend.DTOs.CertificateDTOs;
using MyExamsBackend.Models;
using MyExamsBackend.Services.Interfaces;

namespace MyExamsBackend.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class CertificatesController : Controller
    {
        private ICertificatesService _certificatesService;

        public CertificatesController(ICertificatesService certificatesService)
        {
            _certificatesService = certificatesService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var results = _certificatesService.GetAll();
            if(!results.Any())
            {
                return NotFound("No Certificate found");
            }
            return Ok(results);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var results = _certificatesService.GetById(id);
            if(results == null)
            {
                return NotFound("Could not find the certificate requested");
            }
            return Ok(results);
        }

        [HttpPost("Create")]
        public IActionResult Create(CreateCertificateRequestDTO createCertificateRequestDto)
        {
            var results = _certificatesService.Create(createCertificateRequestDto);
            if(results == false)
            {
                return BadRequest("Invalid certificate");
            }
            return Ok("New certificate created");
        }

        [HttpPut("Update")]
        public IActionResult Update(UpdateCertificateRequestDTO updateCertificateRequestDto)
        {
            var result = _certificatesService.Update(updateCertificateRequestDto);
            if(result == false)
            {
                return BadRequest("Invalid Certificate");
            }
            return Ok("Certificate Updated");
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            var results = _certificatesService.Delete(id);
            if(results == false)
            {
                return BadRequest("Could not find the certificate requested");
            }
            return Ok("Certificate deleted");
        }
    }
}
