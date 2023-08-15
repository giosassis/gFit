using AutoMapper;
using gFit.Context.DTOs;
using gFit.Models;
using gFit.Repositories.Interface;
using gFit.Services.Interfaces;

using static gFit.Context.DTOs.TrainingSeries;

namespace gFit.Services.Implementation
{
    public class TrainingSeriesService : ITrainingSeriesService
    {
        private readonly IMapper _mapper;
        private readonly ITrainingSeriesRepository _trainingSeriesRepository;

        public TrainingSeriesService(IMapper mapper, ITrainingSeriesRepository trainingSeriesRepository)
        {
            _mapper = mapper;
            _trainingSeriesRepository = trainingSeriesRepository;
        }

        public async Task<IEnumerable<TrainingSeriesReadDTO>> GetAllTrainingSeriesAsync()
        {
            var trainingSeries = await _trainingSeriesRepository.GetAllTrainingSeriesAsync();
            return _mapper.Map<IEnumerable<TrainingSeriesReadDTO>>(trainingSeries);
        }

        public async Task<TrainingSeriesReadDTO> GetTrainingSeriesByIdAsync(Guid id)
        {
            var trainingSeries = await _trainingSeriesRepository.GetTrainingSeriesByIdAsync(id);
            return _mapper.Map<TrainingSeriesReadDTO>(trainingSeries);
        }

        public async Task<TrainingSeriesReadDTO> CreateTrainingSeriesAsync(TrainingSeriesCreateDTO trainingSeriesCreateDTO)
        {
            var trainingSeries = _mapper.Map<Models.TrainingSeries>(trainingSeriesCreateDTO);

            var createdTrainingSeries = await _trainingSeriesRepository.CreateTrainingSeriesAsync(trainingSeries);
            return _mapper.Map<TrainingSeriesReadDTO>(createdTrainingSeries);
        }

        public async Task<TrainingSeriesReadDTO> UpdateTrainingSeriesAsync(Guid id, TrainingSeriesUpdateDTO trainingSeriesUpdateDTO)
        {
            var existingTrainingSeries = await _trainingSeriesRepository.GetTrainingSeriesByIdAsync(id);

            if (existingTrainingSeries == null)
            {
                throw new Exception("Training series not found");
            }

            _mapper.Map(trainingSeriesUpdateDTO, existingTrainingSeries);

            var updatedTrainingSeries = await _trainingSeriesRepository.UpdateTrainingSeriesAsync(id, existingTrainingSeries);
            return _mapper.Map<TrainingSeriesReadDTO>(updatedTrainingSeries);
        }

        public async Task DeleteTrainingSeriesAsync(Guid id)
        {
            var existingTrainingSeries = await _trainingSeriesRepository.GetTrainingSeriesByIdAsync(id);

            if (existingTrainingSeries == null)
            {
                return;
            }

            await _trainingSeriesRepository.DeleteTrainingSeriesAsync(id);
        }

        public async Task AddExerciseToTrainingSeriesAsync(int trainingSeriesId, ExerciseDto exerciseDto)
        {
            var trainingSeries = await _trainingSeriesRepository.GetTrainingSeriesByIdAsync(trainingSeriesId);

            if (trainingSeries == null)
            {
                throw new Exception("Training series not found");
            }

            var exercise = _mapper.Map<Exercise>(exerciseDto);
            trainingSeries.Exercises.Add(exercise);

            await _trainingSeriesRepository.UpdateTrainingSeriesAsync(trainingSeriesId, trainingSeries);
        }
    }
}
