using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogAPISQLServer.Models
{
    public class Comment
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(500)]
        public string Message { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string Author { get; set; } = string.Empty;

        [ForeignKey(nameof(Blog))]
        public int BlogId { get; set; }

        public Blog? Blog { get; set; }
    }
}
