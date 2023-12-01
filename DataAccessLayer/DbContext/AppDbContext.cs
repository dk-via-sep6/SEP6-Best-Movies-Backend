using Microsoft.EntityFrameworkCore;
using DomainLayer.Entities;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Example configuration
        modelBuilder.Entity<UserDomain>(entity =>
        {
            entity.HasKey(e => e.Id);
            // Configure other properties and relationships
        });
    }
    public DbSet<UserDomain> Users { get; set; }
}
