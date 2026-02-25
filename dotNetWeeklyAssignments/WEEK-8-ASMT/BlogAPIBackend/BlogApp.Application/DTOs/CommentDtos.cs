using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.DTOs
{
    public class CommentCreateDto
    {
        public string Message { get; set; } = string.Empty;

        public int BlogId { get; set; }

        public int? ParentCommentId { get; set; }    

    }
    public class CommentUpdateDto
    {
        public string Message { get; set; } = string.Empty;
    }

    public class CommentReadDto
    {
        public int Id { get; set; }
        public string Message { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public int BlogId { get; set; }
    }
}