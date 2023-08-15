using System;
namespace gFit.Models
{
	public class ExerciseImage
	{
        public Guid Id { get; set; }
        public int ExerciseId { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Exercise? Exercise { get; set; }
    }
}
