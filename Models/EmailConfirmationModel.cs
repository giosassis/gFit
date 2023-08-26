namespace gFit.Models
{
	public class EmailConfirmationModel
	{
        public string? Email { get; set; }
        public DateTime ExpirationTime { get; set; }
        public string? Token { get; set; }
    }
}

