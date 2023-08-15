using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;
using gFit.Models;

namespace gFit.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string? Name { get; set; }

        public string? Username { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }

        public float? Weight { get; set; }
        public float? Height { get; set; }

        [Required]
        public int Age { get; set; }

        public string? Habits { get; set; }

        [Required]
        public DateTime Birthdate { get; set; }

        public float? Imc { get; set; }
        public float? BodyFatPercentage { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public DateTime UpdatedAt { get; set; }

        [ForeignKey("AddressId")]
        public Guid AddressId { get; set; }
        public ICollection<Address>? Address { get; set; }

        [ForeignKey("TrainingSeriesId")]
        public Guid TrainingSeriesId { get; set; }
        public ICollection<TrainingSeries>? TrainingSeries { get; set; }
    }
}

