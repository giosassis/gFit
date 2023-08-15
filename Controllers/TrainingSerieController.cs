
using Microsoft.AspNetCore.Mvc;
using gFit.Services.Interfaces;
using static gFit.Context.DTOs.TrainingSeries;

namespace gFit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingSeriesController : ControllerBase
    {
        private readonly ITrainingSeriesService _trainingSeriesService;

        public TrainingSeriesController(ITrainingSeriesService trainingSeriesService)
        {
            _trainingSeriesService = trainingSeriesService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTrainingSeries()
        {
            var trainingSeries = await _trainingSeriesService.GetAllTrainingSeriesAsync();
            return Ok(trainingSeries);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTrainingSeriesById(Guid id)
        {
            var trainingSeries = await _trainingSeriesService.GetTrainingSeriesByIdAsync(id);

            if (trainingSeries == null)
            {
                return NotFound();
            }

            return Ok(trainingSeries);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTrainingSeries(TrainingSeriesCreateDTO trainingSeriesCreateDTO)
        {
            var createdTrainingSeries = await _trainingSeriesService.CreateTrainingSeriesAsync(trainingSeriesCreateDTO);
            return CreatedAtAction(nameof(GetTrainingSeriesById), new { id = createdTrainingSeries.Id }, createdTrainingSeries);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTrainingSeries(Guid id, TrainingSeriesUpdateDTO trainingSeriesUpdateDTO)
        {
            var updatedTrainingSeries = await _trainingSeriesService.UpdateTrainingSeriesAsync(id, trainingSeriesUpdateDTO);

            if (updatedTrainingSeries == null)
            {
                return NotFound();
            }

            return Ok(updatedTrainingSeries);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrainingSeries(Guid id)
        {
            await _trainingSeriesService.DeleteTrainingSeriesAsync(id);
            return NoContent();
        }
    }
}
