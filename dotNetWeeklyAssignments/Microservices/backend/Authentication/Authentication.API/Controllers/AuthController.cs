using Microsoft.AspNetCore.Mvc;
using Authentication.Application.DTOs;
using Authentication.Domain.Entities;
using Authentication.Infrastructure.Data;
using MongoDB.Driver;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace Authentication.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly MongoDbContext _context;
    private readonly IConfiguration _configuration;

    public AuthController(MongoDbContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterDto dto)
    {
        var user = new User
        {
            Id = Guid.NewGuid().ToString(),
            Name = dto.Name,
            Email = dto.Email,
            Password = dto.Password, // In real app, hash this!
            Role = dto.Role
        };

        await _context.Users.InsertOneAsync(user);
        return Ok(new { message = "User registered successfully" });
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto dto)
    {
        var user = await _context.Users.Find(u => u.Email == dto.Email && u.Password == dto.Password).FirstOrDefaultAsync();
        
        if (user == null) return Unauthorized("Invalid credentials");

        var token = GenerateJwtToken(user);
        return Ok(new { token = token, user = user.Name, role = user.Role.ToString() });
    }

    private string GenerateJwtToken(User user)
    {
        var secret = _configuration["Jwt:Secret"] ?? "default_very_long_secret_key_for_development_purposes";
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(ClaimTypes.Name, user.Name),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, user.Role.ToString())
        };

        var token = new JwtSecurityToken(
            issuer: "LMSAuth",
            audience: "LMSSystem",
            claims: claims,
            expires: DateTime.Now.AddHours(2),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
