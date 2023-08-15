using AutoMapper;
using gFit.Context.DTOs;
using gFit.Models;
using gFit.Repositories.Interface;
using gFit.Services.Interface;
using static gFit.Context.DTOs.ExerciseDto;

namespace gFit.Services.Implementation
{
    public class ExerciseService : IExerciseService
    {
        private readonly IMapper _mapper;
        private readonly IExerciseRepository _exerciseRepository;
        private readonly ITrainingSeriesRepository _trainingSeriesRepository;

        public ExerciseService(IMapper mapper, IExerciseRepository exerciseRepository, ITrainingSeriesRepository trainingSeriesRepository)
        {
            _mapper = mapper;
            _exerciseRepository = exerciseRepository;
            _trainingSeriesRepository = trainingSeriesRepository;
        }

        public async Task<IEnumerable<ExerciseReadDTO>> GetAllExercisesAsync()
        {
            var exercises = await _exerciseRepository.GetAllExercisesAsync();
            return _mapper.Map<IEnumerable<ExerciseReadDTO>>(exercises);
        }

        public async Task<ExerciseReadDTO> GetExerciseByIdAsync(Guid id)
        {
            var exercise = await _exerciseRepository.GetExerciseByIdAsync(id);
            return _mapper.Map<ExerciseReadDTO>(exercise);
        }

        public async Task<ExerciseReadDTO> CreateExerciseAsync(ExerciseCreateDTO exerciseCreateDTO)
        {
            var exercise = _mapper.Map<Exercise>(exerciseCreateDTO);

            var createdExercise = await _exerciseRepository.CreateExerciseAsync(exercise);
            return _mapper.Map<ExerciseReadDTO>(createdExercise);
        }

        public async Task<ExerciseReadDTO> UpdateExerciseAsync(Guid id, ExerciseUpdateDTO exerciseUpdateDTO)
        {
            var existingExercise = await _exerciseRepository.GetExerciseByIdAsync(id);

            if (existingExercise == null)
            {
                throw new Exception("Exercise not found");
            }

            _mapper.Map(exerciseUpdateDTO, existingExercise);

            var updatedExercise = await _exerciseRepository.UpdateExerciseAsync(id, existingExercise);
            return _mapper.Map<ExerciseReadDTO>(updatedExercise);
        }

        public async Task DeleteExerciseAsync(Guid id)
        {
            var existingExercise = await _exerciseRepository.GetExerciseByIdAsync(id);

            if (existingExercise == null)
            {
                return;
            }

            await _exerciseRepository.DeleteExerciseAsync(id);
        }

        public async Task AddExerciseToTrainingSeriesAsync(Guid trainingSeriesId, ExerciseDto exerciseDto, int repetitions, int sets, float restInterval)
        {
            var trainingSeries = await _trainingSeriesRepository.GetTrainingSeriesByIdAsync(trainingSeriesId);

            if (trainingSeries == null)
            {
                throw new Exception("Training series not found");
            }

            var exercise = _mapper.Map<Exercise>(exerciseDto);
            exercise.Repetitions = repetitions;
            exercise.Sets = sets;
            exercise.RestInterval = restInterval;

            trainingSeries.Exercises.Add(exercise);

            await _trainingSeriesRepository.UpdateTrainingSeriesAsync(trainingSeriesId, trainingSeries);
        }
    }
}
