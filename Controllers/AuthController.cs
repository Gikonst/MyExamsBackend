using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Scripting;
using MyExamsBackend.Domain;
using MyExamsBackend.DTOs.UserDTOs;
using MyExamsBackend.Models;
using MyExamsBackend.Auth;
using System.Configuration;

namespace MyExamsBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private ApplicationDbContext _context; 
        private readonly IConfiguration _configuration;

        public AuthController(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterUserDTO registerUser)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            if(_context.Users.Any(u => u.Email == registerUser.Email))
                return BadRequest(new {message = "Email already exists"});

            var newUser = new User
            {
                FirstName = registerUser.FirstName,
                LastName = registerUser.LastName,
                Email = registerUser.Email,
                Password = registerUser.Password,
                Role = UserRoleType.User
            };

            _context.Users.Add(newUser);
            _context.SaveChanges();

            return Ok(new {mewssage = "User registered successfully"});
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginUserDto loginUser)
        {
            var user = _context.Users.SingleOrDefault(u => u.Email == loginUser.Email);

            if(user == null)
                return Unauthorized(new {message = "Invalid email or password"});

            bool isPasswordValid = loginUser.Password == user.Password;
            if (!isPasswordValid)
            {
                return Unauthorized(new { message = "Invalid email or password" });
            }
            var token = new TokenGenerator(_configuration).GenerateJwtToken(user);

            return Ok(new {token, userId = user.Id, userRole = user.Role});
        }
    }
}
