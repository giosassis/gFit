using System;
namespace gFit.Context.DTOs
{
	public class AddressDto
	{
        public class AddressReadDTO
        {
            public int Id { get; set; }
            public string? Street { get; set; }
            public string? City { get; set; }
            public string? State { get; set; }
            public string? PostalCode { get; set; }
            public string? HouseNumber { get; set; }
            public DateTime CreatedAt { get; set; }
            public DateTime UpdatedAt { get; set; }
        }

        public class AddressCreateDTO
        {
            public string? Street { get; set; }
            public string? City { get; set; }
            public string? State { get; set; }
            public string? PostalCode { get; set; }
            public string? HouseNumber { get; set; }
        }

        public class AddressUpdateDTO
        {
            public string? Street { get; set; }
            public string? City { get; set; }
            public string? State { get; set; }
            public string? PostalCode { get; set; }
            public string? HouseNumber { get; set; }
        }
    }
}

