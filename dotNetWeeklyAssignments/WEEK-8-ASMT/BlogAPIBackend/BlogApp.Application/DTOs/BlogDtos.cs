using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BlogApp.Application.DTOs
{
    public class BlogCreateDto
    {
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
    }

    public class BlogUpdateDto : BlogCreateDto { }

    public class BlogReadDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;

        public List<CommentReadDto> Comments { get; set; } = new();
    }
}