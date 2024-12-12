using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
                return NotFound();
            }
            return Ok(results);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var results = _certificatesService.GetById(id);
            if(results == null)
            {
                return NotFound();
            }
            return Ok(results);
        }

        [HttpPost("Create")]
        public IActionResult Create(Certificate certificate)
        {
            var results = _certificatesService.Create(certificate);
            if(results == false)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpPut("Update")]
        public IActionResult Update(Certificate certificate)
        {
            var result = _certificatesService.Update(certificate);
            if(result == false)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            var results = _certificatesService.Delete(id);
            if(results == false)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
