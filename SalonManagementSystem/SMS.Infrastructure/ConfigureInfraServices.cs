using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using FluentValidation;
using SMS.Infrastructure.Profiles;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using SMS.Infrastructure;

namespace SMS.Application
{
    public static class InfraServiceRegistration
    {
        public static IServiceCollection ConfigureInfraServices(this IServiceCollection services)
        {
            // Register AutoMapper with the current executing assembly
            services.AddAutoMapper(typeof(MappingProfile).Assembly);
            return services;
        }
    }
}
