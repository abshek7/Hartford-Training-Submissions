using System.Xml.Linq;

namespace BlogAPI.Models
{
    public class Blog
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public List<Comment>? Comments { get; set; }
    }
}
