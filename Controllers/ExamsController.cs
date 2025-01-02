using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyExamsBackend.DTOs.ExamDTOs;
using MyExamsBackend.DTOs.TestDTOs;
using MyExamsBackend.Models;
using MyExamsBackend.Services;
using MyExamsBackend.Services.Interfaces;

namespace MyExamsBackend.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class ExamsController : Controller
    {
        private IExamsService _examsService;

        public ExamsController(IExamsService examsService)
        {
            _examsService = examsService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var results = await _examsService.GetAllAsync();
            if(!results.Any())
            {
                return NotFound("No exam found");
            }
            return Ok(results);
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var results = await _examsService.GetByIdAsync(id);
            if(results == null)
            {
                return NotFound("Could not find the exam requested");
            }
            return Ok(results);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateExamRequestDTO createExamRequestDto)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();
                return BadRequest(new { message = "Validation errors occurred.", errors });
            }
            var results = await _examsService.CreateAsync(createExamRequestDto);
            if(results == false)
            {
                return BadRequest("Invalid exam");
            }
            return Ok("Exam created");
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(UpdateExamRequestDTO updateExamRequestDto)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();
                return BadRequest(new { message = "Validation errors occurred.", errors });
            }
            var results = await _examsService.UpdateAsync(updateExamRequestDto);
            if(results == false)
            {
                return BadRequest("Invalid exam");
            }
            return Ok("Exam updated" );
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var results = await _examsService.DeleteAsync(id);
            if (results == false)
            {
                return BadRequest("Could not find the exam requested");
            }
            return Ok("Exam deleted");
        }

        [HttpPost("submit/{examId}")]
        public async Task<IActionResult> SubmitAnswersAsync(int examId, [FromBody] List<TestUserAnswersDTO> userAnswers)
        {
            if (userAnswers == null || !userAnswers.Any())
            {
                return BadRequest("No answers provided.");
            }

            // Call the service method to calculate score and pass status
            var (score, passed) = await _examsService.CalculateScoreAsync(examId, userAnswers);

            return Ok(new
            {
                Score = score,
                Passed = passed,
            });
        }
    }
}
