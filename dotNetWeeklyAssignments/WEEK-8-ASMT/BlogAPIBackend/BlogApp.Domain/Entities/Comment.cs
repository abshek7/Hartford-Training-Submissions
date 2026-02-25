//namespace BlogApp.Domain.Entities
//{
//    public class Comment
//    {
//        public int Id { get; set; }
//        public string Message { get; set; } = string.Empty;
//        public string Author { get; set; } = string.Empty;

//        public int BlogId { get; set; }
//        public Blog? Blog { get; set; }
//    }
//}

namespace BlogApp.Domain.Entities
{
    public class Comment
    {
        public int Id { get; set; }

        public string Message { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;

        public int BlogId { get; set; }
        public Blog? Blog { get; set; }
        public int? ParentCommentId { get; set; }
        public Comment? ParentComment { get; set; }

        public List<Comment> Replies { get; set; } = new();
        public int? UserId { get; set; }
    }
}