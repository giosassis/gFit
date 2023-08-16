using AutoMapper;
using gFit.Models;
using gFit.Repositories.Interface;
using gFit.Services.Interface;
using static gFit.Context.DTOs.ExerciseCategoryDto;

namespace gFit.Services.Implementation
{
    public class ExerciseCategoryService : IExerciseCategoryService
    {
        private readonly IMapper _mapper;
        private readonly IExerciseCategoryRepository _exerciseCategoryRepository;

        public ExerciseCategoryService(IMapper mapper, IExerciseCategoryRepository exerciseCategoryRepository)
        {
            _mapper = mapper;
            _exerciseCategoryRepository = exerciseCategoryRepository;
        }

        public async Task<IEnumerable<ExerciseCategoryReadDTO>> GetAllExerciseCategoriesAsync()
        {
            var exerciseCategories = await _exerciseCategoryRepository.GetAllExerciseCategoriesAsync();
            return _mapper.Map<IEnumerable<ExerciseCategoryReadDTO>>(exerciseCategories);
        }

        public async Task<ExerciseCategoryReadDTO> GetExerciseCategoryByIdAsync(Guid id)
        {
            var exerciseCategory = await _exerciseCategoryRepository.GetExerciseCategoryByIdAsync(id);
            return _mapper.Map<ExerciseCategoryReadDTO>(exerciseCategory);
        }

        public async Task<ExerciseCategoryReadDTO> CreateExerciseCategoryAsync(ExerciseCategoryCreateDTO exerciseCategoryCreateDTO)
        {
            var exerciseCategory = _mapper.Map<ExerciseCategory>(exerciseCategoryCreateDTO);

            exerciseCategory.CreatedAt = DateTime.UtcNow;
            exerciseCategory.UpdatedAt = DateTime.UtcNow;


            var createdExerciseCategory = await _exerciseCategoryRepository.CreateExerciseCategoryAsync(exerciseCategory);
            return _mapper.Map<ExerciseCategoryReadDTO>(createdExerciseCategory);
        }

        public async Task<ExerciseCategoryReadDTO> UpdateExerciseCategoryAsync(Guid id, ExerciseCategoryUpdateDTO exerciseCategoryUpdateDTO)
        {
            var existingExerciseCategory = await _exerciseCategoryRepository.GetExerciseCategoryByIdAsync(id);

            if (existingExerciseCategory == null)
            {
                throw new Exception("Exercise Category not found");
            }

            var updatedExerciseCategory = await _exerciseCategoryRepository.UpdateExerciseCategoryAsync(id, existingExerciseCategory);
            return _mapper.Map<ExerciseCategoryReadDTO>(updatedExerciseCategory);
        }

        public async Task DeleteExerciseCategoryAsync(Guid id)
        {
            var existingExerciseCategory = await _exerciseCategoryRepository.GetExerciseCategoryByIdAsync(id);

            if (existingExerciseCategory == null)
            {
                return;
            }

            await _exerciseCategoryRepository.DeleteExerciseCategoryAsync(id);
        }
    }
}
