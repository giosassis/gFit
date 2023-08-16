using gFit.Context.DTOs;
using gFit.Models;
using static gFit.Context.DTOs.ExerciseImageDto;

namespace gFit.Services.Interface
{
    public interface IExerciseImageService
    {
        Task<IEnumerable<ExerciseImageReadDTO>> GetAllExerciseImageAsync();
        Task<ExerciseImageReadDTO> GetExerciseImageByIdAsync(Guid id);
        Task<ExerciseImageReadDTO> CreateExerciseImageAsync(ExerciseImageCreateDTO equipmentDTO);
        Task<ExerciseImageReadDTO> UpdateExerciseImageAsync(Guid id, ExerciseImageUpdateDTO equipmentDTO);
        Task DeleteExerciseImageAsync(Guid id);
    }
}
