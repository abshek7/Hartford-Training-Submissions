using System.ComponentModel.DataAnnotations;

namespace BlogAPISQLServer.Models
{
    public class Blog
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Content { get; set; } = string.Empty;

        public List<Comment> Comments { get; set; } = new();
    }
}
