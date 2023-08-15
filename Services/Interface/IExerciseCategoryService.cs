using static gFit.Context.DTOs.ExerciseCategoryDto;

namespace gFit.Services.Interface
{
    public interface IExerciseCategoryService
    {
        Task<IEnumerable<ExerciseCategoryReadDTO>> GetAllExerciseCategoriesAsync();
        Task<ExerciseCategoryReadDTO> GetExerciseCategoryByIdAsync(Guid id);
        Task<ExerciseCategoryReadDTO> CreateExerciseCategoryAsync(ExerciseCategoryCreateDTO exerciseCategoryCreateDTO);
        Task<ExerciseCategoryReadDTO> UpdateExerciseCategoryAsync(Guid id, ExerciseCategoryUpdateDTO exerciseCategoryUpdateDTO);
        Task DeleteExerciseCategoryAsync(Guid id);
    }
}
