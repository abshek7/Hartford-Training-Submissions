using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RbacAuthJwt.Data;
using RbacAuthJwt.DTOs;
using RbacAuthJwt.Models;
using RbacAuthJwt.Service;
 
namespace BlogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthDbContext _db;
        private readonly JwtService _jwt;
        private readonly PasswordHasher<User> _hasher = new();

        public AuthController(AuthDbContext db, JwtService jwt)
        {
            _db = db;
            _jwt = jwt;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            if (await _db.Users.AnyAsync(x => x.UserName == dto.UserName))
                return BadRequest("User exists");

            var user = new User
            {
                UserName = dto.UserName,
                Role = dto.Role ?? "User"
            };

            user.PasswordHash = _hasher.HashPassword(user, dto.Password);

            _db.Users.Add(user);
            await _db.SaveChangesAsync();

            var token = _jwt.GenerateToken(user);

            return Ok(new AuthResultDto(token, user.UserName, user.Role));
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var user = await _db.Users.FirstOrDefaultAsync(x => x.UserName == dto.UserName);
            if (user == null) return Unauthorized();

            var result = _hasher.VerifyHashedPassword(user, user.PasswordHash, dto.Password);
            if (result == PasswordVerificationResult.Failed) return Unauthorized();

            var token = _jwt.GenerateToken(user);

            return Ok(new AuthResultDto(token, user.UserName, user.Role));
        }
    }
}
