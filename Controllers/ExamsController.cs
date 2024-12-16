using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyExamsBackend.DTOs.ExamDTOs;
using MyExamsBackend.Models;
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
        public IActionResult GetAll()
        {
            var results = _examsService.GetAll();
            if(!results.Any())
            {
                return NotFound("No exam found");
            }
            return Ok(results);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var results = _examsService.GetById(id);
            if(results == null)
            {
                return NotFound("Could not find the exam requested");
            }
            return Ok(results);
        }

        [HttpPost("Create")]
        public IActionResult Create([FromBody]CreateExamRequestDTO createExamRequestDto)
        {
            var results = _examsService.Create(createExamRequestDto);
            if(results == false)
            {
                return BadRequest("Invalid exam");
            }
            return Ok("Exam created");
        }

        [HttpPut("Update")]
        public IActionResult Update(UpdateExamRequestDTO updateExamRequestDto)
        {
            var results = _examsService.Update(updateExamRequestDto);
            if(results == false)
            {
                return BadRequest("Invalid exam");
            }
            return Ok("Exam updated");
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            var results = _examsService.Delete(id);
            if (results == false)
            {
                return BadRequest("Could not find the exam requested");
            }
            return Ok("Exam deleted");
        }
    }
}
