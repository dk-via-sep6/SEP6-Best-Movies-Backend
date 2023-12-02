using DataAccessLayer.DbContextFolder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "..", "SEP6-Best-Movies-Backend")))
            .AddJsonFile("appsettings.json")
            .Build();

        var builder = new DbContextOptionsBuilder<AppDbContext>();
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        builder.UseSqlServer(connectionString);

        return new AppDbContext(builder.Options);
    }
}
