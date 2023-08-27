using System;
namespace gFit.Context.DTOs
{
	public class PersonalDto
	{
        public class PersonalReadDTO
        {
            public Guid Id { get; set; }
            public string? Name { get; set; }
            public string? Email { get; set; }
            public bool IsEmailConfirmed { get; set; }
            public string? Cref { get; set; }
            public string? Description { get; set; }
            public DateTime CreatedAt { get; set; }
            public DateTime UpdatedAt { get; set; }
            public Guid AddressId { get; set; }
        }

        public class PersonalCreateDTO
        {
            public string? Name { get; set; }
            public string? Email { get; set; }
            public string? Password { get; set; }
            public string? Cref { get; set; }
            public string? Description { get; set; }
            public Guid AddressId { get; set; }
        }

        public class PersonalUpdateDTO
        {
            public string? Name { get; set; }
            public string? Email { get; set; }
            public bool IsEmailConfirmed { get; set; }
            public string? Password { get; set; }
            public string? Description { get; set; }
            public DateTime UpdatedAt { get; set; }
        }
    }
}

