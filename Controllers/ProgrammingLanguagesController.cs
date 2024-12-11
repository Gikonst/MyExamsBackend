using Microsoft.AspNetCore.Mvc;
using MyExamsBackend.Models;
using MyExamsBackend.Services;
using MyExamsBackend.Services.Interfaces;

namespace MyExamsBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProgrammingLanguagesController : Controller
    {
        
        private IProgrammingLanguagesService _programmingLanguagesService;

        public ProgrammingLanguagesController(IProgrammingLanguagesService programmingLanguagesService)
        {
            _programmingLanguagesService = programmingLanguagesService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var results = _programmingLanguagesService.GetAll();
            if (!results.Any())
            {
                return NotFound();
            }
            return Ok(results);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var results = _programmingLanguagesService.GetById(id);
            if (results == null)
            {
                return NotFound();
            }
            return Ok(results);
        }

        [HttpPost("Create")]
        public IActionResult Create(ProgrammingLanguage programmingLanguage)
        {
            var results = _programmingLanguagesService.Create(programmingLanguage);
            if (results == false)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpPut("Update")]
        public IActionResult Update(ProgrammingLanguage programmingLanguage)
        {
            var results = _programmingLanguagesService.Update(programmingLanguage);
            if (results == false)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            var results = _programmingLanguagesService.Delete(id);
            if (results == false)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
