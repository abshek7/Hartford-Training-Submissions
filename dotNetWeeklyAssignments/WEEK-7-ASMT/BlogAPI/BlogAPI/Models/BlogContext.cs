using Microsoft.EntityFrameworkCore;

namespace BlogAPI.Models
{
    public class BlogContext:DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options) : base(options) { }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Comment> Comments { get; set; }


    }
}
