using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnionArch.Persistence.Context
{
    public class ApplicationDbContextDesignFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder= new DbContextOptionsBuilder<ApplicationDbContext>()
                                .UseNpgsql("Host=localhost;Port=5432;Database=OnionArchExample;Username=muratcant;Password=PostgreSQL1.");
            return new ApplicationDbContext(optionsBuilder.Options);

        }
    }
}
