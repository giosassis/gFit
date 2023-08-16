using Microsoft.AspNetCore.Mvc;
using gFit.Services.Interface;
using static gFit.Context.DTOs.ExerciseDto;

namespace gFit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseController : ControllerBase
    {
        private readonly IExerciseService _exerciseService;

        public ExerciseController(IExerciseService exerciseService)
        {
            _exerciseService = exerciseService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetExercise(Guid id)
        {
            var exercise = await _exerciseService.GetExerciseByIdAsync(id);

            if (exercise == null)
            {
                return NotFound();
            }

            return Ok(exercise);
        }

        [HttpPost]
        public async Task<IActionResult> CreateExercise(ExerciseCreateDTO exerciseCreateDTO)
        {
            var createdExercise = await _exerciseService.CreateExerciseAsync(exerciseCreateDTO);
            return CreatedAtAction(nameof(GetExercise), new { id = createdExercise.Id }, createdExercise);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateExercise(Guid id, ExerciseUpdateDTO exerciseUpdateDTO)
        {
            var updatedExercise = await _exerciseService.UpdateExerciseAsync(id, exerciseUpdateDTO);

            if (updatedExercise == null)
            {
                return NotFound();
            }

            return Ok(updatedExercise);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExercise(Guid id)
        {
            await _exerciseService.DeleteExerciseAsync(id);
            return NoContent();
        }
    }
}
