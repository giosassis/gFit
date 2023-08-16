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

        public PersonalController(IPersonalService personalService)
        {
            _personalService = personalService;
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

        [HttpPost]
        public async Task<IActionResult> CreatePersonal(PersonalCreateDTO personalCreateDTO)
        {
            var createdPersonal = await _personalService.CreatePersonalAsync(personalCreateDTO);
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
