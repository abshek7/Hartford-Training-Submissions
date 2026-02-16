using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace BlogAPISQLServer.Models
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> options)
            : base(options)
        {
        }

        public DbSet<Blog> Blogs => Set<Blog>();
        public DbSet<Comment> Comments => Set<Comment>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>()
                .HasMany(b => b.Comments)
                .WithOne(c => c.Blog)
                .HasForeignKey(c => c.BlogId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
