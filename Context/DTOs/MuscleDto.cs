using System;
namespace gFit.Context.DTOs
{
	public class MuscleDto
	{
        public class MuscleReadDTO
        {
            public Guid Id { get; set; }
            public string? Name { get; set; }
            public string? Description { get; set; }
            public DateTime CreatedAt { get; set; }
            public DateTime UpdatedAt { get; set; }
        }

        public class MuscleCreateDTO
        {
            public string? Name { get; set; }
            public string? Description { get; set; }
        }

        public class MuscleUpdateDTO
        {
            public string? Name { get; set; }
            public string? Description { get; set; }
        }
    }
}

