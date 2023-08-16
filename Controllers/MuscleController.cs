using Microsoft.AspNetCore.Mvc;
using gFit.Services.Interface;
using static gFit.Context.DTOs.MuscleDto;

namespace gFit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MuscleController : ControllerBase
    {
        private readonly IMuscleService _muscleService;

        public MuscleController(IMuscleService muscleService)
        {
            _muscleService = muscleService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMuscle(Guid id)
        {
            var muscle = await _muscleService.GetMuscleByIdAsync(id);

            if (muscle == null)
            {
                return NotFound();
            }

            return Ok(muscle);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMuscle(MuscleCreateDTO muscleCreateDTO)
        {
            var createdMuscle = await _muscleService.CreateMuscleAsync(muscleCreateDTO);
            return CreatedAtAction(nameof(GetMuscle), new { id = createdMuscle.Id }, createdMuscle);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMuscle(Guid id, MuscleUpdateDTO muscleUpdateDTO)
        {
            var updatedMuscle = await _muscleService.UpdateMuscleAsync(id, muscleUpdateDTO);

            if (updatedMuscle == null)
            {
                return NotFound();
            }

            return Ok(updatedMuscle);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMuscle(Guid id)
        {
            await _muscleService.DeleteMuscleAsync(id);
            return NoContent();
        }
    }
}
