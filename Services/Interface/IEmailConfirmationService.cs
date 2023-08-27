<<<<<<< HEAD
﻿namespace gFit.Services.Interface
{
	public interface IEmailConfirmationService
    {
        Task<bool> VerifyEmailTokenAsync(string email, string token);
        Task<bool> ConfirmEmailAsync(string email, string token);
        Task SendConfirmationEmailAsync(string email, string confirmationLink, string personalName);
    }
}
=======
﻿using System;
namespace gFit.Services.Interface
{
	public interface IEmailConfirmationService
	{
        Task SendConfirmationEmailAsync(string email, string confirmationLink, string personalName);
    }
}

>>>>>>> 003d765eabac9824d2c7ed685066ad4f1344f2e7
