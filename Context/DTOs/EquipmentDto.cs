using System;
namespace gFit.Context.DTOs
{
	public class EquipmentDto
	{
        public class EquipmentReadDTO
        {
            public int Id { get; set; }
            public string? Name { get; set; }
            public string? Description { get; set; }
            public DateTime CreatedAt { get; set; }
            public DateTime UpdatedAt { get; set; }
        }

        public class EquipmentCreateDTO
        {
            public string? Name { get; set; }
            public string? Description { get; set; }
        }

        public class EquipmentUpdateDTO
        {
            public string? Name { get; set; }
            public string? Description { get; set; }
        }
    }
}

