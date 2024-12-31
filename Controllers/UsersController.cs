using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyExamsBackend.DTOs.UserDTOs;
using MyExamsBackend.Models;
using MyExamsBackend.Services;
using MyExamsBackend.Services.Interfaces;

namespace MyExamsBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private IUsersService _usersService;
        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet("GetAll")]
        [Authorize(Policy = "AdminPolicy")]
        public IActionResult GetAll()
        {
            var results = _usersService.GetAll();
            if (!results.Any())
            {
                return NotFound();
            }
            return Ok(results);
        }

        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            var results = _usersService.GetById(id);
            if (results == null)
            {
                return NotFound();
            }
            return Ok(results);
        }

        [HttpPut("Update")]
        public IActionResult Update(UpdateUserRequestDTO updateUser)
        {
            var results = _usersService.Update(updateUser);
            if (results == false)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            var results = _usersService.Delete(id);
            if ( results == false)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
