using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Application.DTO;
using Application.Repositories.User;
using Domain.Identity;
using Microsoft.IdentityModel.Tokens;

namespace Application.Services
{
    public class AuthenticationService
    {
        private readonly IUserReadRepository _userReadRepository;
        private readonly string _jwtSecretKey;

        public AuthenticationService(IUserReadRepository userReadRepository, string jwtSecretKey)
        {
            _userReadRepository = userReadRepository;
            _jwtSecretKey = jwtSecretKey;
        }

        public async Task<LoginResponseDto> AuthenticateAsync(LoginRequestDto request)
        {
            var user = await _userReadRepository.GetByIdAsync(request.Username);

            if (user == null || !VerifyPassword(request.Password, user.PasswordHash))
            {
                return null; // Ya da geçersiz kimlik bilgileri için bir istisna fırlatabilirsiniz
            }

            var token = GenerateJwtToken(user);
            var expiration = DateTime.UtcNow.AddHours(2);

            return new LoginResponseDto
            {
                Token = token,
                Expiration = expiration
            };
        }

        private bool VerifyPassword(string password, string storedHash)
        {
            // Şifre doğrulama mantığını uygulayın, örneğin bir karma algoritması kullanarak
            return true;
        }

        private string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }

}
