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
        public async Task<IActionResult> GetAll()
        {
            var results = await _certificatesService.GetAllAsync();
            if(!results.Any())
            {
                return NotFound("No Certificate found");
            }
            return Ok(results);
        }

        [HttpGet("GetByUserId")]
      
        public async Task<IActionResult> GetByUserId(int id)
        {
            var results = await _certificatesService.GetByUserIdAsync(id);
            if(results == null)
            {
                return NotFound("Could not find the certificate requested");
            }
            return Ok(results);
        }


        [HttpPost("Create/{examId}")]
        public async Task<IActionResult> Create(int examId, [FromQuery]int userId)
        {
            var results = await _certificatesService.CreateAsync( examId, userId);
            if (results == false)
            {
                return BadRequest("You have already passed this exam");
            }
            return Ok("New certificate created");
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var results = await _certificatesService.DeleteAsync(id);
            if(results == false)
            {
                return BadRequest("Could not find the certificate requested");
            }
            return Ok("Certificate deleted");
        }

        [HttpGet("download")]
        public async Task<IActionResult> DownloadCertificate([FromQuery] int id)
        {
            try
            {
                // Generate the certificate PDF
                byte[] pdfBytes = await _certificatesService.GenerateCertificateAsync(id);

               
                return File(pdfBytes, "application/pdf", "Certificate.pdf");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
