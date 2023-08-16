using AutoMapper;
using gFit.Models;
using gFit.Repositories.Interface;
using gFit.Services.Interface;
using static gFit.Context.DTOs.ExerciseImageDto;

namespace gFit.Services.Implementation
{
    public class ExerciseImageService : IExerciseImageService
    {
        private readonly IMapper _mapper;
        private readonly IExerciseImageRepository _exerciseImageRepository;

        public ExerciseImageService(IMapper mapper, IExerciseImageRepository exerciseImageRepository)
        {
            _mapper = mapper;
            _exerciseImageRepository = exerciseImageRepository;
        }

        public async Task<IEnumerable<ExerciseImageReadDTO>> GetAllExerciseImageAsync()
        {
            var exerciseImages = await _exerciseImageRepository.GetAllExerciseImagesAsync();
            return _mapper.Map<IEnumerable<ExerciseImageReadDTO>>(exerciseImages);
        }

        public async Task<ExerciseImageReadDTO> GetExerciseImageByIdAsync(Guid id)
        {
            var exerciseImage = await _exerciseImageRepository.GetExerciseImageByIdAsync(id);
            return _mapper.Map<ExerciseImageReadDTO>(exerciseImage);
        }

        public async Task<ExerciseImageReadDTO> CreateExerciseImageAsync(ExerciseImageCreateDTO exerciseImageCreateDTO)
        {
            var exerciseImage = _mapper.Map<ExerciseImage>(exerciseImageCreateDTO);

            exerciseImage.CreatedAt = DateTime.UtcNow;
            exerciseImage.UpdatedAt = DateTime.UtcNow;


            var createdExerciseImage = await _exerciseImageRepository.CreateExerciseImageAsync(exerciseImage);
            return _mapper.Map<ExerciseImageReadDTO>(createdExerciseImage);
        }

        public async Task<ExerciseImageReadDTO> UpdateExerciseImageAsync(Guid id, ExerciseImageUpdateDTO exerciseImageUpdateDTO)
        {
            var existingExerciseImage = await _exerciseImageRepository.GetExerciseImageByIdAsync(id);

            if (existingExerciseImage == null)
            {
                throw new Exception("Exercise Image not found");
            }

            var updatedExerciseImage = await _exerciseImageRepository.UpdateExerciseImageAsync(id, existingExerciseImage);
            return _mapper.Map<ExerciseImageReadDTO>(updatedExerciseImage);
        }

        public async Task DeleteExerciseImageAsync(Guid id)
        {
            var existingExerciseImage = await _exerciseImageRepository.GetExerciseImageByIdAsync(id);

            if (existingExerciseImage == null)
            {
                return;
            }

            await _exerciseImageRepository.DeleteExerciseImageAsync(id);
        }
    }
}
