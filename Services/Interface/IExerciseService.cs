using System;
using gFit.Models;
using static gFit.Context.DTOs.ExerciseDto;

namespace gFit.Services.Interface
{
    public interface IExerciseService
    {
        Task<IEnumerable<ExerciseReadDTO>> GetAllExercisesAsync();
        Task<ExerciseReadDTO> GetExerciseByIdAsync(Guid id);
        Task<ExerciseReadDTO> CreateExerciseAsync(ExerciseCreateDTO exerciseDTO);
        Task<ExerciseReadDTO> UpdateExerciseAsync(Guid id, ExerciseUpdateDTO exerciseDTO);
        Task DeleteExerciseAsync(Guid id);
    }
}


