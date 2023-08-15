using System;
namespace gFit.Context.DTOs
{
	public class ExerciseDto
	{
        public class ExerciseReadDTO
        {
            public int Id { get; set; }
            public string? Name { get; set; }
            public string? Description { get; set; }
            public int ExerciseCategoryId { get; set; }
            public int MuscleId { get; set; }
            public int EquipmentId { get; set; }
            public DateTime CreatedAt { get; set; }
            public DateTime UpdatedAt { get; set; }
        }

        public class ExerciseCreateDTO
        {
            public string? Name { get; set; }
            public string? Description { get; set; }
            public int ExerciseCategoryId { get; set; }
            public int MuscleId { get; set; }
            public int EquipmentId { get; set; }
        }

        public class ExerciseUpdateDTO
        {
            public string? Name { get; set; }
            public string? Description { get; set; }
        }
    }
}

