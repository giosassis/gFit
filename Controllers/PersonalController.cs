using Microsoft.AspNetCore.Mvc;
using gFit.Services.Interface;
using static gFit.Context.DTOs.PersonalDto;
<<<<<<< HEAD
using Microsoft.AspNetCore.Cors;
using gFit.Services.Implementation;
using Newtonsoft.Json.Linq;
=======
>>>>>>> de58bf75660d62e8496836152c1eea71d4844232

namespace gFit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalController : ControllerBase
    {
        private readonly IPersonalService _personalService;
<<<<<<< HEAD
        private readonly IEmailConfirmationService _emailConfirmationService;

        public PersonalController(IPersonalService personalService, IEmailConfirmationService emailConfirmationService)
        {
            _personalService = personalService;
            _emailConfirmationService = emailConfirmationService;
=======
        private readonly IJwtService _jwtService;
        private readonly IEmailConfirmationService _emailConfirmationService;

        public PersonalController(IPersonalService personalService, IEmailConfirmationService emailConfirmationService, IJwtService jwtService)
        {
            _personalService = personalService;
            _emailConfirmationService = emailConfirmationService;
            _jwtService = jwtService;

>>>>>>> de58bf75660d62e8496836152c1eea71d4844232
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTrainingSeries()
        {
            var personal = await _personalService.GetAllPersonalsAsync();
            return Ok(personal);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPersonal(Guid id)
        {
            var personal = await _personalService.GetPersonalByIdAsync(id);

            if (personal == null)
            {
                return NotFound();
            }

            return Ok(personal);
        }

        [HttpGet("{getbyemail}")]
        public async Task<IActionResult> GetPersonalByEmail(string email)
        {
            try
            {
                var personal = await _personalService.GetPersonalByEmailAsync(email);
                if (personal == null)
                {
                    return NotFound();
                }

                return Ok(personal);
            }
            catch (Exception ex)
            {
                // Lidar com exceções ou retornar BadRequest se algo der errado
                return BadRequest("Error retrieving personal by email.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreatePersonal(PersonalCreateDTO personalCreateDTO)
        {
            var createdPersonal = await _personalService.CreatePersonalAsync(personalCreateDTO);
<<<<<<< HEAD
            var confirmationLink = $"http://localhost:3000/verificar-email/{Uri.EscapeDataString(createdPersonal.Email)}/{createdPersonal.EmailConfirmationToken}";
            //var confirmationLink = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}/api/EmailConfirmation/verify?email={Uri.EscapeDataString(createdPersonal.Email)}&token={createdPersonal.EmailConfirmationToken}";
            await _emailConfirmationService.SendConfirmationEmailAsync(createdPersonal.Email, confirmationLink, createdPersonal.Name);

=======

            var token = _jwtService.GenerateEmailConfirmationToken(createdPersonal.Email);
            var confirmationLink = $"http://localhost:3000/confirmacao/{Uri.EscapeDataString(createdPersonal.Email)}/{token}";
            await _emailConfirmationService.SendConfirmationEmailAsync(createdPersonal.Email, confirmationLink, createdPersonal.Name);
>>>>>>> de58bf75660d62e8496836152c1eea71d4844232
            return CreatedAtAction(nameof(GetPersonal), new { id = createdPersonal.Id }, createdPersonal);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePersonal(Guid id, PersonalUpdateDTO personalUpdateDTO)
        {
            var updatedPersonal = await _personalService.UpdatePersonalAsync(id, personalUpdateDTO);

            if (updatedPersonal == null)
            {
                return NotFound();
            }

            return Ok(updatedPersonal);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonal(Guid id)
        {
            await _personalService.DeletePersonalAsync(id);
            return NoContent();
        }

        [HttpGet("getbyemail")]
        public async Task<IActionResult> GetPersonalByEmail(string email)
        {
            try
            {
                var personal = await _personalService.GetPersonalByEmailAsync(email);
                if (personal == null)
                {
                    return NotFound();
                }

                return Ok(personal);
            }
            catch (Exception ex)
            {
                // Lidar com exceções ou retornar BadRequest se algo der errado
                return BadRequest("Error retrieving personal by email.");
            }
        }
    }
}
