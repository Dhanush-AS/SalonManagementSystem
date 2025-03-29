using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using FluentValidation;

namespace SMS.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
        {
            // Register AutoMapper with the current executing assembly

            // Register FluentValidation validators
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
