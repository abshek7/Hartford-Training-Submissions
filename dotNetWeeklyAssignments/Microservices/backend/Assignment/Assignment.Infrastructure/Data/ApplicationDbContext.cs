using Microsoft.EntityFrameworkCore;
using Assignment.Domain.Entities;

namespace Assignment.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Assignment.Domain.Entities.Assignment> Assignments { get; set; }
    public DbSet<Submission> Submissions { get; set; }
}
