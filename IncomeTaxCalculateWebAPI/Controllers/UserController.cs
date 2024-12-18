using IncomeTaxCalculate.Application.Interfaces;
using IncomeTaxCalculate.Application.Services;
using IncomeTaxCalculate.Domain.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IncomeTaxCalculate.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/user/{id}
        [HttpGet("{userId}")]
        public async Task<ActionResult<UserModel?>> GetUserByIdAsync(int userId)
        {
            var user = await _userService.GetUserByIdAsync(userId);

            if (user == null)
            {
                return NotFound(); // Returns 404 if user not found
            }

            return Ok(user); // Returns 200 with user data
        }

        [HttpPost]
        [Route("insert")]
        public async Task<IActionResult> InsertUserAsync([FromBody] UserModel userDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var user = await _userService.InsertUserAsync(userDto);

                //// Return created user without sensitive data (e.g., PasswordHash)
                //return CreatedAtAction(nameof(GetUserByIdAsync), new { userId = user.UserId }, new
                //{
                //    user.UserId,
                //    user.Username,
                //    user.Email,
                //    //user.Permissions,
                //    //user.Roles,
                //});

                return Ok(new UserModel() { Username=user.Username,Email=user.Email});    
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred.", details = ex.Message });
            }
        }
    }
}
