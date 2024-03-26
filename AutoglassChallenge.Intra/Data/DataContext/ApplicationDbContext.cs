using AutoglassChallenge.Domain.Entities;
using AutoglassChallenge.Intra.Mappings;
using Microsoft.EntityFrameworkCore;

namespace AutoglassChallenge.Intra.Data.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) => ChangeTracker.LazyLoadingEnabled = false;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            modelBuilder.ApplyConfiguration(new ProductMap());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("SQLConnection");
            }
        }
    }
}
