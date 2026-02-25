using BlogApp.Application.DTOs;
using BlogApp.Application.Interfaces;
using BlogApp.Application.Services;
using BlogApp.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;

namespace BlogApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _userRepo;
        private readonly IJwtService _jwt;

        public AuthController(IUserRepository userRepo, IJwtService jwt)
        {
            _userRepo = userRepo;
            _jwt = jwt;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            var existing = await _userRepo.GetByEmailAsync(dto.Email);

            if (existing != null)
                return BadRequest("Email already exists");

            var user = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                Role = dto.Role,
                PasswordHash = Hash(dto.Password)
            };

            await _userRepo.AddAsync(user);

            return Ok(new { message = "User registered successfully" });
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthResponseDto>> Login(LoginDto dto)
        {
            var user = await _userRepo.GetByEmailAsync(dto.Email);

            if (user == null || user.PasswordHash != Hash(dto.Password))
                return Unauthorized("Invalid credentials");

            var token = _jwt.GenerateToken(user.Id, user.Name, user.Role);

            return new AuthResponseDto
            {
                Token = token,
                Name = user.Name,
                Role = user.Role
            };
        }

        private string Hash(string password)
        {
            using var sha = SHA256.Create();
            return Convert.ToBase64String(
                sha.ComputeHash(Encoding.UTF8.GetBytes(password)));
        }
    }
}