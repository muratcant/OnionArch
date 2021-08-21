using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OnionArch.Application.Interfaces.Repository;
using OnionArch.Persistence.Context;
using OnionArch.Persistence.Repositories;

namespace OnionArch.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql("Host=localhost;Port=5432;Database=OnionArchExample;Username=muratcant;Password=PostgreSQL1."));

            serviceCollection.AddTransient<IProductRepository, ProductRepository>();
        }
    }
}
