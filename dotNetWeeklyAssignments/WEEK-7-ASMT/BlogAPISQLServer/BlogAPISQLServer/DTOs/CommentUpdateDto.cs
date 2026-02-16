using System.ComponentModel.DataAnnotations;

namespace BlogAPISQLServer.DTOs
{
    public class CommentUpdateDto
    {
        [Required]
        [MaxLength(500)]
        public string Message { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string Author { get; set; } = string.Empty;
    }
}
