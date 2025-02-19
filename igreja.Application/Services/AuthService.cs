using igreja.Application.Interfaces;
using igreja.Domain.Interfaces;
using igreja.Domain.Models;
using Igreja.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Igreja.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;
        private readonly IUserContextProvider _userContextProvider;

        public AuthService(IUserRepository userRepository, IConfiguration configuration, IUserContextProvider userContextProvider)
        {
            _userRepository = userRepository;
            _configuration = configuration;
            _userContextProvider = userContextProvider;
        }

        public string Login(string username, string password)
        {
            var user = _userRepository.GetUserByUsernameAsync(username).Result;

            if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
                return null;

            return GenerateJwtToken(user);
        }

        public async Task<bool> LogoutAsync(string token)
        {
            // Limpa o contexto do usuário
            //_userContextProvider.ClearCurrentUser();
            return true;
        }

        private string GenerateJwtToken(User user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role),
                new Claim("tenantId", user.TenantId.ToString()),
                new Claim("userId", user.Id.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(3),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
