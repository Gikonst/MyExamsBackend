using Microsoft.AspNetCore.Mvc;
using MyExamsBackend.DTOs.ProgrammingLanguageDTOs;
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
                return NotFound("No programming language found");
            }
            return Ok(results);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var results = _programmingLanguagesService.GetById(id);
            if (results == null)
            {
                return NotFound("Could not find the programming language requested");
            }
            return Ok(results);
        }

        [HttpPost("Create")]
        public IActionResult Create(CreateProgrammingLanguageRequestDTO createProgrammingLanguageRequestDto)
        {
            var results = _programmingLanguagesService.Create(createProgrammingLanguageRequestDto);
            if (results == false)
            {
                return BadRequest("Invalid programming language");
            }
            return Ok("Programming language created");
        }

        [HttpPut("Update")]
        public IActionResult Update(UpdateProgrammingLanguageRequestDTO updateProgrammingLanguageRequestDto)
        {
            var results = _programmingLanguagesService.Update(updateProgrammingLanguageRequestDto);
            if (results == false)
            {
                return BadRequest("Invalid programming language");
            }
            return Ok("Programming language updated");
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            var results = _programmingLanguagesService.Delete(id);
            if (results == false)
            {
                return BadRequest("Could not find the programming language requested");
            }
            return Ok("Programming language deleted");
        }
    }
}
