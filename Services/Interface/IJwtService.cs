using System;
namespace gFit.Services.Interface
{
    public interface IJwtService
    {
        string GenerateEmailConfirmationToken(string email);
        bool ValidateEmailConfirmationToken(string token);
    }

}

