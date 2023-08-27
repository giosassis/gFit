using Microsoft.AspNetCore.Mvc;
using gFit.Services.Interface;
using gFit.Services.Implementation;
using static gFit.Context.DTOs.PersonalDto;

namespace gFit.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmailConfirmationController : ControllerBase
    {
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
        }
    }
}
