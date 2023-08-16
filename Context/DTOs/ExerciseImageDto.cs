namespace gFit.Context.DTOs
{
	public class ExerciseImageDto
	{
        public class ExerciseImageReadDTO
        {
            public Guid Id { get; set; }
            public string? ImageUrl { get; set; }
            public string? Name { get; set; }
            public DateTime CreatedAt { get; set; }
            public DateTime UpdatedAt { get; set; }
        }

        public class ExerciseImageCreateDTO
        {
            public string? ImageUrl { get; set; }
            public string? Name { get; set; }
        }

        public class ExerciseImageUpdateDTO
        {
            public string? ImageUrl { get; set; }
            public string? Name { get; set; }
        }
    }
}

