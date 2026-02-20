namespace BlogAPISQLServer.DTOs
{
    public class BlogReadDto
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Content { get; set; } = string.Empty;

        public List<CommentReadDto> Comments { get; set; } = new();
    }
}
