using System;
namespace gFit.Context.DTOs
{
	public class ExerciseCategoryDto
	{
        public class ExerciseCategoryReadDTO
        {
            public int Id { get; set; }
            public string? Name { get; set; }
            public string? Description { get; set; }
            public DateTime CreatedAt { get; set; }
            public DateTime UpdatedAt { get; set; }
        }

        public class ExerciseCategoryCreateDTO
        {
            public string? Name { get; set; }
            public string? Description { get; set; }
        }

        public class ExerciseCategoryUpdateDTO
        {
            public string? Name { get; set; }
            public string? Description { get; set; }
        }
    }
}

