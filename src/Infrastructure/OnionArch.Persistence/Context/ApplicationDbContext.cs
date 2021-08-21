using Microsoft.EntityFrameworkCore;
using OnionArch.Domain.Entities;
using System;

namespace OnionArch.Persistence.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public const string DEFAULT_SCHEMA = "catalog";

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
