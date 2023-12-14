using DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;


namespace DataAccessLayer.DbContextFolder
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserDomain>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.EmailAddress)
                      .IsRequired()
                      .HasMaxLength(100);
                entity.HasIndex(e => e.EmailAddress).IsUnique();
                entity.Property(e => e.Username)
                      .IsRequired()
                      .HasMaxLength(50);
            });
            modelBuilder.Entity<CommentDomain>(entity =>
            {
                entity.Property<int>("MovieId").IsRequired();
                entity.Property<string>("AuthorId").IsRequired();
                entity.HasOne<UserDomain>().WithMany().HasForeignKey(c => c.AuthorId);
                entity.Property<string>("AuthorUsername");
            });
            modelBuilder.Entity<RatingDomain>(entity =>
            {
                entity.Property<int>("MovieId").IsRequired();
                entity.Property<string>("UserId").IsRequired();
                entity.HasOne<UserDomain>().WithMany().HasForeignKey(c => c.UserId);
            });
            modelBuilder.Entity<WatchlistDomain>(entity =>
            {
                entity.HasKey(w => w.Id);
                entity.Property(w => w.Id).ValueGeneratedOnAdd();
                entity.Property(w => w.Name)
                      .IsRequired()
                      .HasMaxLength(100);
                entity.Property<string>("UserId").IsRequired();
                entity.HasOne<UserDomain>().WithMany().HasForeignKey(w => w.UserId);
            });
        }
        public DbSet<UserDomain> Users { get; set; }
        public DbSet<CommentDomain> Comments { get; set; }
        public DbSet<RatingDomain> MovieRatings { get; set; }
        public DbSet<WatchlistDomain> Watchlists { get; set; }
    }
}
