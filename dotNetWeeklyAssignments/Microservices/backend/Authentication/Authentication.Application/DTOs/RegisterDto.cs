using Authentication.Domain.Entities;

namespace Authentication.Application.DTOs;

public class RegisterDto
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public Role Role { get; set; }
}
