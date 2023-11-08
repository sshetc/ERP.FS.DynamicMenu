using Microsoft.Extensions.DependencyInjection;
using DynamicMenu.Application.Common.Mappings;
using System.Reflection;
using FluentValidation;
using MediatR;
using DynamicMenu.Application.Common.Behaviors;
using DynamicMenu.Application.Interfaces;

namespace DynamicMenu.Application.Extension.DependencyExtension
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, Assembly webApiAssembly)
        {
            services.AddHttpClient();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            services.AddAutoMapper(config =>
            {
                config.AddProfile(new AssemblyMappingProfile(webApiAssembly));
                config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
                config.AddProfile(new AssemblyMappingProfile(typeof(IDynamicMenuDbContext).Assembly));
            });
            services.AddValidatorsFromAssemblies(new[] { Assembly.GetExecutingAssembly() });
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            return services;
        }
    }
}
