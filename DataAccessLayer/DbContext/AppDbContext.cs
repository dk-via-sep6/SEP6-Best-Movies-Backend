using Microsoft.EntityFrameworkCore;
using DomainLayer.Entities;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<UserDomain> Users { get; set; }
}
