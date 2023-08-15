using System;
namespace gFit.Context.DTOs
{
	public class UserDto
	{
        public class UserReadDTO
        {
            public int Id { get; set; }
            public string? Name { get; set; }
            public string? Username { get; set; }
            public string? Email { get; set; }
            public float? Weight { get; set; }
            public float? Height { get; set; }
            public int Age { get; set; }
            public string? Habits { get; set; }
            public DateTime Birthdate { get; set; }
            public float? Imc { get; set; }
            public float? BodyFatPercentage { get; set; }
            public DateTime CreatedAt { get; set; }
            public DateTime UpdatedAt { get; set; }
            public int AddressId { get; set; }
        }

        public class UserCreateDTO
        {
            public string? Name { get; set; }
            public string? Username { get; set; }
            public string? Email { get; set; }
            public string? Password { get; set; }
            public float? Weight { get; set; }
            public float? Height { get; set; }
            public int Age { get; set; }
            public string? Habits { get; set; }
            public DateTime Birthdate { get; set; }
        }

        public class UserUpdateDTO
        {
            public string? Name { get; set; }
            public string? Username { get; set; }
            public float? Weight { get; set; }
            public string? Password { get; set; }
            public int Age { get; set; }
            public float? Height { get; set; }
            public string? Habits { get; set; }
            public DateTime Birthdate { get; set; }
        }
    }
}

