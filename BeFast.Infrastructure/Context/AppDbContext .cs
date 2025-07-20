using BeFast.Domain.Entities;
using BeFast.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace BeFast.Infrastructure.Context
{

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>()
                .Property(u => u.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<User>()
                .Property(u => u.Type)
                .HasConversion(
                    v => v.ToString(),
                    v => (UserType)Enum.Parse(typeof(UserType), v));

            modelBuilder.Entity<User>()
                .Property(u => u.CreatedAt)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<User>()
                .Property(u => u.IsActive)
                .HasDefaultValue(true);


            base.OnModelCreating(modelBuilder);
        }
    }
}
