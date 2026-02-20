using System.ComponentModel.DataAnnotations;

namespace BlogAPISQLServer.DTOs
{
    public class BlogUpdateDto
    {
        [Required]
        [MaxLength(200)]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Content { get; set; } = string.Empty;
    }
}
