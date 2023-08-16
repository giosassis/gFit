using System.ComponentModel.DataAnnotations.Schema;

namespace gFit.Models
{
	public class Exercise
	{
        public Guid Id { get; set; }
        public Guid ExerciseCategoryId { get; set; }
        public Guid MuscleId { get; set; }
        public Guid EquipmentId { get; set; }
        public string? Name { get; set; }
        public int Repetitions { get; set; }  
        public int Sets { get; set; } 
        public float RestInterval { get; set; }  
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Guid? ExerciseImageId { get; set; }
        [ForeignKey("ExerciseImageId")]
        public ExerciseImage? ExerciseImage { get; set; }
        [ForeignKey("ExerciseCategoryId")]
        public ExerciseCategory? ExerciseCategory { get; set; }
        [ForeignKey("MuscleId")]
        public Muscle? Muscle { get; set; }
        [ForeignKey("EquipmentId")]
        public Equipment? Equipment { get; set; }
        public List<TrainingSeries>? TrainingSeries { get; set; }
    }
}

