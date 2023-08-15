using System;
using System.Net;

namespace gFit.Models
{
	public class Personal
	{
      public Guid Id { get; set; }
      public string? Name { get; set; }
      public string? Email { get; set; }
      public string? Password { get; set; }
      public string? Cref { get; set; }
      public string? Description { get; set; }
      public DateTime CreatedAt { get; set; }
      public DateTime UpdatedAt { get; set; }
      public int AddressId { get; set; }
      public Address? Address { get; set; }
        
	}
}

