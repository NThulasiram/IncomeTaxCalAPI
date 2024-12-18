using IncomeTaxCalculate.Application.Interfaces;
using IncomeTaxCalculate.Application.Services;
using IncomeTaxCalculate.Domain.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IncomeTaxCalculate.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly JwtService _jwtService;

        public AuthController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _jwtService = new JwtService(configuration);
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginModel login)
        {

            var user = await _userService.ValidateUserAsync(login.Username, login.Password);
            if (user == null)
            {
                return Unauthorized("Invalid username or password");
            }

            // Generate JWT token
            var token = _jwtService.GenerateToken(user.UserId.ToString(), user.Username);
            return Ok(new { Token = token });
        }
    }
}
