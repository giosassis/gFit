using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace gFit.Models
{
	public class ExerciseImage
	{
        public Guid Id { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }


        // [ForeignKey("ExerciseId")]
        public required Guid ExerciseId { get; set; }
        public required Exercise Exercise { get; set; } = null!;
    }
}
