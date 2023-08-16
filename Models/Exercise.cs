using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace gFit.Models
{
	public class Exercise
	{
        public Guid Id { get; set; }
        [ForeignKey("ExerciseCategoryId")]
        public Guid ExerciseCategoryId { get; set; }
        [ForeignKey("MuscleId")]
        public Guid MuscleId { get; set; }
        [ForeignKey("EquipmentId")]
        public Guid EquipmentId { get; set; }
        public string? Name { get; set; }
        public int Repetitions { get; set; }  
        public int Sets { get; set; } 
        public float RestInterval { get; set; }  
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }


        // [ForeignKey("ExerciseImageId")]
        public Guid? ExerciseImageId { get; set; }
        public ExerciseImage? ExerciseImage { get; set; }


        public ExerciseCategory? ExerciseCategory { get; set; }
        public Muscle? Muscle { get; set; }
        public Equipment? Equipment { get; set; }

        public List<TrainingSeries>? TrainingSeries { get; set; }
    }
}

