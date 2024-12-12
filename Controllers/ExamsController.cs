using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
                return NotFound();
            }
            return Ok(results);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var results = _examsService.GetById(id);
            if(results == null)
            {
                return NotFound();
            }
            return Ok(results);
        }

        [HttpPost("Create")]
        public IActionResult Create(Exam exam)
        {
            var results = _examsService.Create(exam);
            if(results == false)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpPut("Update")]
        public IActionResult Update(Exam exam)
        {
            var results = _examsService.Update(exam);
            if(results == false)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            var results = _examsService.Delete(id);
            if (results == false)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
