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
        public async Task<IActionResult> GetAll()
        {
            var results = await _usersService.GetAllAsync();
            if (!results.Any())
            {
                return NotFound();
            }
            return Ok(results);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery]int id)
        {
            var results = await _usersService.GetByIdAsync(id);
            if (results == null)
            {
                return NotFound();
            }
            return Ok(results);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(UpdateUserRequestDTO updateUser)
        {
            var results = await _usersService.UpdateAsync(updateUser);
            if (results == false)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var results = await _usersService.DeleteAsync(id);
            if ( results == false)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
