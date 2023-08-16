using Microsoft.AspNetCore.Mvc;
using gFit.Services.Interface;
using static gFit.Context.DTOs.ExerciseCategoryDto;

namespace gFit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseCategoryController : ControllerBase
    {
        private readonly IExerciseCategoryService _exerciseCategoryService;

        public ExerciseCategoryController(IExerciseCategoryService exerciseCategoryService)
        {
            _exerciseCategoryService = exerciseCategoryService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetExerciseCategory(Guid id)
        {
            var exerciseCategory = await _exerciseCategoryService.GetExerciseCategoryByIdAsync(id);

            if (exerciseCategory == null)
            {
                return NotFound();
            }

            return Ok(exerciseCategory);
        }

        [HttpPost]
        public async Task<IActionResult> CreateExerciseCategory(ExerciseCategoryCreateDTO exerciseCategoryCreateDTO)
        {
            var createdExerciseCategory = await _exerciseCategoryService.CreateExerciseCategoryAsync(exerciseCategoryCreateDTO);
            return CreatedAtAction(nameof(GetExerciseCategory), new { id = createdExerciseCategory.Id }, createdExerciseCategory);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateExerciseCategory(Guid id, ExerciseCategoryUpdateDTO exerciseCategoryUpdateDTO)
        {
            var updatedExerciseCategory = await _exerciseCategoryService.UpdateExerciseCategoryAsync(id, exerciseCategoryUpdateDTO);

            if (updatedExerciseCategory == null)
            {
                return NotFound();
            }

            return Ok(updatedExerciseCategory);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExerciseCategory(Guid id)
        {
            await _exerciseCategoryService.DeleteExerciseCategoryAsync(id);
            return NoContent();
        }
    }
}
