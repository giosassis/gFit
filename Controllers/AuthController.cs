using Microsoft.AspNetCore.Mvc;
using gFit.Context.DTOs;
using gFit.Services.Interface;
using System.Threading.Tasks;

namespace gFit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var authResult = await _authService.LoginAsync(loginDTO);

            if (!authResult.Success)
            {
                return Unauthorized(new { message = authResult.Message });
            }

            return Ok(new { message = authResult.Message, token = authResult.Token });
        }
    }
}
