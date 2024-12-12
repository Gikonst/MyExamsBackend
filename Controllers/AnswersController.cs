using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult GetAll()
        {
            var results = _answersService.GetAll();
            if (!results.Any())
            {
                return NotFound();
            }
            return Ok(results);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var results = _answersService.GetById(id);
            if(results == null)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpPost("Create")]
        public IActionResult Create(Answer answer)
        {
            var results = _answersService.Create(answer);
            if(results == false)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpPut("Update")]
        public IActionResult Update(Answer answer)
        {
            var results = _answersService.Update(answer);
            if(results == false)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            var results = _answersService.Delete(id);
            if(results == false)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
