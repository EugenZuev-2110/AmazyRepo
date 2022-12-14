using Amazy.Entities;
using Microsoft.EntityFrameworkCore;

namespace Amazy.Context
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Sneaker> Sneakers { get; set; }

        public ApplicationContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;user=root;password=322398;database=amazydb;",
                new MySqlServerVersion(new Version(8, 0, 30)));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.Sneakers)
                .WithMany(s => s.Users)
                .UsingEntity(p => p.ToTable("UsersSneakers"));
        }
    }
}
