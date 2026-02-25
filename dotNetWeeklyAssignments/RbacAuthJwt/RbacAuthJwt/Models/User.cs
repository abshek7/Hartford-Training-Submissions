using System.ComponentModel.DataAnnotations;
namespace RbacAuthJwt.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required] public string UserName { get; set; } = null!;
        [Required] public string PasswordHash { get; set; } = null!;

        public string Role { get; set; } = "User";

    }
}
