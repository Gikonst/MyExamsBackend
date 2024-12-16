using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Create(Question question)
        {
            var results = _QuestionsService.Create(question);
            if (results == false)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpPut("Update")]
        public IActionResult Update(Question question)
        {
            var results = _QuestionsService.Update(question);
            if (results == false)
            {
                return BadRequest();
            }
            return Ok();
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
