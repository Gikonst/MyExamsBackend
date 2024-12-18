using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyExamsBackend.DTOs.CertificateDTOs;
using MyExamsBackend.Models;
using MyExamsBackend.Services;
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

        [HttpGet("GetByUserId")]
      
        public IActionResult GetByUserId(int id)
        {
            var results = _certificatesService.GetByUserId(id);
            if(results == null)
            {
                return NotFound("Could not find the certificate requested");
            }
            return Ok(results);
        }

        [HttpPost("Enroll")]
        public IActionResult Enroll(CertificateRequestDTO createCertificateRequestDto)
        {
            var results = _certificatesService.Enroll(createCertificateRequestDto);
            if(results == false)
            {
                return BadRequest("Invalid certificate");
            }
            return Ok("New certificate created");
        }

        [HttpPost("FinalizeCertificate")]
        public IActionResult FinalizeCertificate(CertificateRequestDTO createCertificateRequestDto)
        {
            var results = _certificatesService.FinalizeCertificate(createCertificateRequestDto);
            if (results == false)
            {
                return BadRequest("Invalid certificate");
            }
            return Ok("New certificate created");
        }

        [HttpPut("Update")]
        public IActionResult Update(CertificateRequestDTO certificateRequestDTO)
        {
            var result = _certificatesService.Update(certificateRequestDTO);
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

        [HttpGet("{id}/download")]
        public IActionResult DownloadCertificate(int id)
        {
            try
            {
                // Generate the certificate PDF
                byte[] pdfBytes = _certificatesService.GenerateCertificate(id);

               
                return File(pdfBytes, "application/pdf", "Certificate.pdf");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
