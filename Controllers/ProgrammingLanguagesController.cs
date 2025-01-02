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
        public async Task<IActionResult> GetAll()
        {
            var results = await _programmingLanguagesService.GetAllAsync();
            if (!results.Any())
            {
                return NotFound("No programming language found");
            }
            return Ok(results);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var results = await _programmingLanguagesService.GetByIdAsync(id);
            if (results == null)
            {
                return NotFound("Could not find the programming language requested");
            }
            return Ok(results);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(ProgrammingLanguageRequestDTO createProgrammingLanguageRequestDto)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();
                return BadRequest(new { message = "Validation errors occurred.", errors });
            }

            var results = await _programmingLanguagesService.CreateAsync(createProgrammingLanguageRequestDto);
            if (results == false)
            {
                return BadRequest("Invalid programming language");
            }
            return Ok(new {message = "Programming language created"});
        }

        [HttpPut("Update")]
        public async Task<ActionResult> Update(ProgrammingLanguageRequestDTO programmingLanguageRequestDto)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();
                return BadRequest(new { message = "Validation errors occurred.", errors });
            }

            var results = await _programmingLanguagesService.UpdateAsync(programmingLanguageRequestDto);
            if (results == false)
            {
                return BadRequest("Invalid programming language");
            }
            return Ok("Programming language updated");
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var results = await _programmingLanguagesService.DeleteAsync(id);
            if (results == false)
            {
                return BadRequest("Could not find the programming language requested");
            }
            return Ok("Programming language deleted");
        }
    }
}
