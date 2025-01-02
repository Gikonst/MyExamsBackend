using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyExamsBackend.DTOs.AnswerDTOs;
using MyExamsBackend.Models;
using MyExamsBackend.Services.Interfaces;

namespace MyExamsBackend.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    
    public class AnswersController : Controller
    {
        private IAnswersService _answersService;

        public AnswersController(IAnswersService answersService)
        {
            _answersService = answersService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var results = await  _answersService.GetAllAsync();
            if (!results.Any())
            {
                return NotFound("No answer found");
            }
            return Ok(results);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var results = await _answersService.GetByIdAsync(id);
            if(results == null)
            {
                return NotFound("Could not find the answer requested");
            }
            return Ok(results);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(AnswerRequestDTO createAnswerRequestDto)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();
                return BadRequest(new { message = "Validation errors occurred.", errors });
            }

            var results = await _answersService.CreateAsync(createAnswerRequestDto);
            if(results == false)
            {
                return BadRequest(new { message = "Failed to create answer" });
            }
            return Ok(new { message = "New answer created" });
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(AnswerRequestDTO updateAnswerRequestDto)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();
                return BadRequest(new { message = "Validation errors occurred.", errors });
            }
            var results = await _answersService.UpdateAsync(updateAnswerRequestDto);
            if(results == false)
            {
                return BadRequest(new { message = "Invalid answer" });
            }
            return Ok(new { message = "Answer updated" });
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var results = await _answersService.DeleteAsync(id);
            if(results == false)
            {
                return BadRequest("Could not find the answer requested");
            }
            return Ok("Answer deleted");
        }
    }
}
