using System.ComponentModel.DataAnnotations;
namespace RbacAuthJwt.Models
{
    public class Blog
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string? Content { get; set; }

        public string Author { get; set; } = null!;

        public DateTime PublishedAt { get; set; }

    }
}
