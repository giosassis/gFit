namespace gFit.Services.Interface
{
	public interface IEmailConfirmationService
    {
        Task<bool> VerifyEmailTokenAsync(string email, string token);
        Task<bool> ConfirmEmailAsync(string email, string token);
        Task SendConfirmationEmailAsync(string email, string confirmationLink, string personalName);
    }
}
