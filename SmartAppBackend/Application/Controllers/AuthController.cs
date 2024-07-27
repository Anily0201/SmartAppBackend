using Microsoft.AspNetCore.Mvc;
using SmartAppBackend.Core.Interfaces;
using SmartAppBackend.Core.Models;
using System.Threading.Tasks;

namespace SmartAppBackend.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] User loginUser)
        {
            var user = await _userService.Authenticate(loginUser.Username, loginUser.Password);
            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }

        [HttpPost("signup")]
        public async Task<IActionResult> Signup([FromBody] User newUser)
        {
            var user = await _userService.Register(newUser);
            return Ok(user);
        }
    }
}
