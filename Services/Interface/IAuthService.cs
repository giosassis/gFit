using System;
using gFit.Utils;
using gFit.Context.DTOs;

namespace gFit.Services.Interface
{
	public interface IAuthService
	{
        Task<AuthResult> LoginAsync(LoginDto loginDTO);
        //Task<AuthResult> LogoutAsync();
        Task<AuthResult> RequestPasswordResetAsync(EmailDto emailDto);
        Task<AuthResult> ResetPasswordAsync(ResetPasswordDto resetPasswordDto);
    }
}

