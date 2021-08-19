using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace OnionArch.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationRegistration(this IServiceCollection serviceCollection)
        {

            var assembly = Assembly.GetExecutingAssembly();

            serviceCollection.AddAutoMapper(assembly);
            serviceCollection.AddMediatR(assembly);
        }
    }
}
