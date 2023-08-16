using Microsoft.AspNetCore.Mvc;
using gFit.Services.Interface;
using static gFit.Context.DTOs.ExerciseImageDto;

namespace gFit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseImageController : ControllerBase
    {
        private readonly IExerciseImageService _exerciseImageService;

        public ExerciseImageController(IExerciseImageService exerciseImageService)
        {
            _exerciseImageService = exerciseImageService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetExerciseImage(Guid id)
        {
            var exerciseImage = await _exerciseImageService.GetEquipmentImageByIdAsync(id);

            if (exerciseImage == null)
            {
                return NotFound();
            }

            return Ok(exerciseImage);
        }

        [HttpPost]
        public async Task<IActionResult> CreateExerciseImage(ExerciseImageCreateDTO exerciseImageCreateDTO)
        {
            var createdExerciseImage = await _exerciseImageService.CreateEquipmentImageAsync(exerciseImageCreateDTO);
            return CreatedAtAction(nameof(GetExerciseImage), new { id = createdExerciseImage.Id }, createdExerciseImage);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateExerciseImage(Guid id, ExerciseImageUpdateDTO exerciseImageUpdateDTO)
        {
            var updatedExerciseImage = await _exerciseImageService.UpdateEquipmentImageAsync(id, exerciseImageUpdateDTO);

            if (updatedExerciseImage == null)
            {
                return NotFound();
            }

            return Ok(updatedExerciseImage);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExerciseImage(Guid id)
        {
            await _exerciseImageService.DeleteExerciseImageAsync(id);
            return NoContent();
        }
    }
}
