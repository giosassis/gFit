using System;
namespace gFit.Services.Interface
{
	public interface IEmailConfirmationService
	{
        Task SendConfirmationEmailAsync(string email, string confirmationLink, string personalName);
    }
}

