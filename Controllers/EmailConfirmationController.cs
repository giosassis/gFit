using Microsoft.AspNetCore.Mvc;
using gFit.Services.Interface;

namespace gFit.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmailConfirmationController : ControllerBase
    {
        private readonly IEmailConfirmationService _emailConfirmationService;

        public EmailConfirmationController(IEmailConfirmationService emailConfirmationService)
        {
            _emailConfirmationService = emailConfirmationService;
        }

        [HttpGet("verify")]
        public async Task<IActionResult> VerifyEmailToken([FromQuery] string email, [FromQuery] string token)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(token))
            {
                return BadRequest("Email and token are required.");
            }

            var isTokenValid = await _emailConfirmationService.VerifyEmailTokenAsync(email, token);

            return Ok(new { IsTokenValid = isTokenValid });
        }

        [HttpGet("confirm")]
        public async Task<IActionResult> ConfirmEmail([FromQuery] string email, [FromQuery] string token)
        {
            Console.WriteLine("ConfirmEmailAsync method called.");

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(token))
            {
                return BadRequest("Email and token are required.");
            }

            var isConfirmed = await _emailConfirmationService.ConfirmEmailAsync(email, token);

            if (isConfirmed)
            {
                // Redirecionar para a página de confirmação bem-sucedida
                return new RedirectResult("http://localhost:3000/confirmacao");
            }

            // Retornar algo caso a confirmação falhe
            return BadRequest("Email confirmation failed.");
        }
    }
}
