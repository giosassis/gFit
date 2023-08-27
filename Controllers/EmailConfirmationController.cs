using Microsoft.AspNetCore.Mvc;
using gFit.Services.Interface;
<<<<<<< HEAD
=======
using gFit.Services.Implementation;
using static gFit.Context.DTOs.PersonalDto;
>>>>>>> de58bf75660d62e8496836152c1eea71d4844232

namespace gFit.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmailConfirmationController : ControllerBase
    {
<<<<<<< HEAD
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
=======
        private readonly IPersonalService _personalService;
        private readonly IJwtService _jwtService;

        public EmailConfirmationController(IPersonalService personalService, IJwtService jwtService)
        {
            _personalService = personalService;
            _jwtService = jwtService;
        }

        [HttpGet("confirm")]
        public async Task<IActionResult> ConfirmEmail(string email, string token)
        {
            try
            {
                if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(token))
                {
                    return BadRequest("Email and token are required.");
                }

                var isValidToken = _jwtService.ValidateEmailConfirmationToken(token);

                if (!isValidToken)
                {
                    return BadRequest("Invalid token.");
                }

                var personal = await _personalService.GetPersonalByEmailAsync(email);

                if (personal == null)
                {
                    return NotFound();
                }

                if (personal.IsEmailConfirmed)
                {
                    return new RedirectResult("http://localhost:3000/confirmacao");  
                }

                personal.IsEmailConfirmed = true;
                await _personalService.UpdatePersonalAsync(personal.Id, new PersonalUpdateDTO { IsEmailConfirmed = true });

                return Ok("Email confirmed successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest("An error occurred while confirming the email.");
            }
>>>>>>> de58bf75660d62e8496836152c1eea71d4844232
        }
    }
}
