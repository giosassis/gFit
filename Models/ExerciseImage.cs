using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace gFit.Models
{
	public class ExerciseImage
	{
        public Guid Id { get; set; }
        [ForeignKey("ExerciseId")]
        public Guid ExerciseId { get; set; }
        public Exercise? Exercise { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
