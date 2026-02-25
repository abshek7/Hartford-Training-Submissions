using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using RbacAuthJwt.Models;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
namespace RbacAuthJwt.Service
{
    public class JwtService
    {
        private readonly IConfiguration _configuration;
        
        public JwtService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(User user)
        {
            var key = _configuration["Jwt:Key"];
            var issuer = _configuration["Jwt:Issuer"];
            var audience = _configuration["Jwt:Audience"];
            var expiresMinutes = int.Parse(_configuration["Jwt:ExpiresMinutes"]!);

            var claims = new List<Claim> {
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                   new Claim(ClaimTypes.Role, user.Role)
            };
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var creds = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(issuer, audience, claims, expires: DateTime.UtcNow.AddMinutes(expiresMinutes), signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);


        }
    }
}
