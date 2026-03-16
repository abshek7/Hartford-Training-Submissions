using Microsoft.EntityFrameworkCore;
using InsuranceManagementApi.Models;

namespace InsuranceManagementApi.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<Policy> Policies => Set<Policy>();
    public DbSet<Claim> Claims => Set<Claim>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure decimal precision for PremiumAmount
        modelBuilder.Entity<Policy>()
            .Property(p => p.PremiumAmount)
            .HasPrecision(18, 2);

        // Configure decimal precision for ClaimAmount
        modelBuilder.Entity<Claim>()
            .Property(c => c.ClaimAmount)
            .HasPrecision(18, 2);
    }
}