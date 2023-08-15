using System;
namespace gFit.Context.DTOs
{
	public class ExerciseImageDto
	{
        public class ExerciseImageReadDTO
        {
            public int Id { get; set; }
            public int ExerciseId { get; set; }
            public string? ImageUrl { get; set; }
            public DateTime CreatedAt { get; set; }
            public DateTime UpdatedAt { get; set; }
        }

        public class ExerciseImageCreateDTO
        {
            public int ExerciseId { get; set; }
            public string? ImageUrl { get; set; }
        }

        public class ExerciseImageUpdateDTO
        {
            public string? ImageUrl { get; set; }
        }
    }
}

