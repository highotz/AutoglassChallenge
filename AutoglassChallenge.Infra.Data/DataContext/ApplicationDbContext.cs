﻿using AutoglassChallenge.Domain.Entities;
using AutoglassChallenge.Intra.Mappings;
using Microsoft.EntityFrameworkCore;

namespace AutoglassChallenge.Intra.Data.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) => ChangeTracker.LazyLoadingEnabled = false;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        }
    }
}
