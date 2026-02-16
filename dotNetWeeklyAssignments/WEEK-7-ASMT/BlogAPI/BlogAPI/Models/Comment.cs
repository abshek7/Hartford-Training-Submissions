namespace BlogAPI.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public string Message { get; set; }

        public string Author { get; set; }

        public int BlogId { get; set; }
    }
}
