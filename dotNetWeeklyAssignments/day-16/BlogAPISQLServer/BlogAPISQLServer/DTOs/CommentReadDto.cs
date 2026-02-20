namespace BlogAPISQLServer.DTOs
{
    public class CommentReadDto
    {
        public int Id { get; set; }

        public string Message { get; set; } = string.Empty;

        public string Author { get; set; } = string.Empty;

        public int BlogId { get; set; }
    }
}
