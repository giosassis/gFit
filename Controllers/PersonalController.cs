using Microsoft.AspNetCore.Mvc;
using gFit.Services.Interface;
using static gFit.Context.DTOs.PersonalDto;

namespace gFit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalController : ControllerBase
    {
        private readonly IPersonalService _personalService;
        private readonly IJwtService _jwtService;
        private readonly IEmailConfirmationService _emailConfirmationService;

        public PersonalController(IPersonalService personalService, IJwtService jwtService, IEmailConfirmationService emailConfirmationService)
        {
            _personalService = personalService;
            _jwtService = jwtService;
            _emailConfirmationService = emailConfirmationService;
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

            var token = _jwtService.GenerateEmailConfirmationToken(createdPersonal.Email);
            var confirmationLink = $"http://localhost:3000/confirmacao/{Uri.EscapeDataString(createdPersonal.Email)}/{token}";
            await _emailConfirmationService.SendConfirmationEmailAsync(createdPersonal.Email, confirmationLink, createdPersonal.Name);
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
    }
}
