
using Microsoft.EntityFrameworkCore;
using RbacAuthJwt.Models;

namespace RbacAuthJwt.Data
{
    public class AuthDbContext:DbContext
    {

        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options) { }
        
        public DbSet<Blog> Blogs =>Set<Blog>();
        public DbSet<User> Users =>Set<User>();

    }
}
