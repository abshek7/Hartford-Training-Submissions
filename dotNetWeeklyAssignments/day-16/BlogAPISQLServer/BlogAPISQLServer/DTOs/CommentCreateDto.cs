using System.ComponentModel.DataAnnotations;

namespace BlogAPISQLServer.DTOs
{
    public class CommentCreateDto
    {
        [Required]
        [MaxLength(500)]
        public string Message { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string Author { get; set; } = string.Empty;

        [Required]
        public int BlogId { get; set; }
    }
}
