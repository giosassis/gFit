using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using gFit.Services.Interface;
using Microsoft.IdentityModel.Tokens;

namespace gFit.Services.Implementation
{
    public class JwtService : IJwtService 
{
        private readonly IConfiguration _configuration;

        public JwtService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateEmailConfirmationToken(string email)
        {
            var secretKey = _configuration["JwtSettings:SecretKey"];
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                new Claim("email", email),
                new Claim("action", "emailConfirmation")  
                }),
                Expires = DateTime.UtcNow.AddMinutes(15),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public bool ValidateEmailConfirmationToken(string token)
        {
            var secretKey = _configuration["JwtSettings:SecretKey"];
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secretKey);

            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,  
                    ValidateAudience = false, 
                    ClockSkew = TimeSpan.Zero  
                }, out _);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }

}
