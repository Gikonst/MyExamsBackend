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
        public IActionResult GetAll()
        {
            var results = _QuestionsService.GetAll();
            if (!results.Any())
            {
                return NotFound();
            }
            return Ok(results);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var results = _QuestionsService.GetById(id);
            if (results == null)
            {
                return NotFound();
            }
            return Ok(results);
        }

        [HttpPost("Create")]
        public IActionResult Create(QuestionRequestDTO newQuestion)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();
                return BadRequest(new { message = "Validation errors occurred.", errors });
            }

            var results = _QuestionsService.Create(newQuestion);
            if (results == false)
            {
                return BadRequest(new { message = "Failed to create question." });
            }
            return Ok(new { message =  "A new question was created"});
        }

        [HttpPut("Update")]
        public IActionResult Update(UpdateQuestionRequestDTO questionDTO)
        {
            var results = _QuestionsService.Update(questionDTO);
            if (results == false)
            {
                return BadRequest();
            }
            return Ok(new { message = "Question updated"});

        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            var results = _QuestionsService.Delete(id);
            if (results == false)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
