using System;
namespace gFit.Context.DTOs
{
	public class TrainingSeries
	{
        public class TrainingSeriesReadDTO
        {
            public int Id { get; set; }
            public int UserId { get; set; }
            public int PersonalId { get; set; }
            public string? Name { get; set; }
            public string? Description { get; set; }
            public int Series { get; set; }
            public int Repetitions { get; set; }
            public float? RestTime { get; set; }
            public DateTime CreatedAt { get; set; }
            public DateTime UpdatedAt { get; set; }
            public List<ExerciseDto> Exercises { get; set; } = new List<ExerciseDto>();
        }

        public class TrainingSeriesCreateDTO
        {
            public int UserId { get; set; }
            public int PersonalId { get; set; }
            public string? Name { get; set; }
            public string? Description { get; set; }
            public int Series { get; set; }
            public int Repetitions { get; set; }
            public float? RestTime { get; set; }
            public List<ExerciseDto> Exercises { get; set; } = new List<ExerciseDto>();
        }

        public class TrainingSeriesUpdateDTO
        {
            public string? Name { get; set; }
            public string? Description { get; set; }
            public int Series { get; set; }
            public int Repetitions { get; set; }
            public float? RestTime { get; set; }
            public List<ExerciseDto> Exercises { get; set; } = new List<ExerciseDto>();
        }
    }
}

