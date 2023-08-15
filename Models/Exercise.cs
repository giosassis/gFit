using System;
namespace gFit.Models
{
	public class Exercise
	{
        public Guid Id { get; set; }
        public int ExerciseImageId { get; set; }
        public int ExerciseCategoryId { get; set; }
        public int MuscleId { get; set; }
        public int EquipmentId { get; set; }
        public string? Name { get; set; }
        public int Repetitions { get; set; }  
        public int Sets { get; set; } 
        public float RestInterval { get; set; }  
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public ExerciseImage? ExerciseImage { get; set; }
        public ExerciseCategory? ExerciseCategory { get; set; }
        public Muscle? Muscle { get; set; }
        public Equipment? Equipment { get; set; }

        public List<TrainingSeries>? TrainingSeries { get; set; }
    }
}

