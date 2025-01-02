﻿using Microsoft.AspNetCore.Http;
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
        public IActionResult GetAll()
        {
            var results = _answersService.GetAll();
            if (!results.Any())
            {
                return NotFound("No answer found");
            }
            return Ok(results);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var results = _answersService.GetById(id);
            if(results == null)
            {
                return NotFound("Could not find the answer requested");
            }
            return Ok(results);
        }

        [HttpPost("Create")]
        public IActionResult Create(AnswerRequestDTO createAnswerRequestDto)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();
                return BadRequest(new { message = "Validation errors occurred.", errors });
            }

            var results = _answersService.Create(createAnswerRequestDto);
            if(results == false)
            {
                return BadRequest(new { message = "Failed to create answer" });
            }
            return Ok(new { message = "New answer created" });
        }

        [HttpPut("Update")]
        public IActionResult Update(AnswerRequestDTO updateAnswerRequestDto)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();
                return BadRequest(new { message = "Validation errors occurred.", errors });
            }
            var results = _answersService.Update(updateAnswerRequestDto);
            if(results == false)
            {
                return BadRequest(new { message = "Invalid answer" });
            }
            return Ok(new { message = "Answer updated" });
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            var results = _answersService.Delete(id);
            if(results == false)
            {
                return BadRequest("Could not find the answer requested");
            }
            return Ok("Answer deleted");
        }
    }
}
