using Microsoft.EntityFrameworkCore;
using Resource.Domain.Entities;

namespace Resource.Infrastructure.Data;

public class ResourceDbContext : DbContext
{
    public ResourceDbContext(DbContextOptions<ResourceDbContext> options) : base(options)
    {
    }

    public DbSet<StudyResource> StudyResources { get; set; }
    public DbSet<QuizQuestion> QuizQuestions { get; set; }
}
