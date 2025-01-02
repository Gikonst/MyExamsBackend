using Microsoft.AspNetCore.Mvc;
using MyExamsBackend.DTOs.QuestionDTOs;
using MyExamsBackend.Models;
using MyExamsBackend.Services;
using MyExamsBackend.Services.Interfaces;

namespace MyExamsBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuestionsController : Controller
    {

        private IQuestionsService _QuestionsService;

        public QuestionsController(IQuestionsService questionsService)
        {
            _QuestionsService = questionsService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var results = await _QuestionsService.GetAllAsync();
            if (!results.Any())
            {
                return NotFound();
            }
            return Ok(results);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var results = await _QuestionsService.GetByIdAsync(id);
            if (results == null)
            {
                return NotFound();
            }
            return Ok(results);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(QuestionRequestDTO newQuestion)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();
                return BadRequest(new { message = "Validation errors occurred.", errors });
            }

            var results = await _QuestionsService.CreateAsync(newQuestion);
            if (results == false)
            {
                return BadRequest(new { message = "Failed to create question." });
            }
            return Ok(new { message =  "A new question was created"});
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(UpdateQuestionRequestDTO questionDTO)
        {
            var results = await _QuestionsService.UpdateAsync(questionDTO);
            if (results == false)
            {
                return BadRequest();
            }
            return Ok(new { message = "Question updated"});

        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var results = await _QuestionsService.DeleteAsync(id);
            if (results == false)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
