using backend.Application.Mappers;
using backend.Application.Services;
using backend.Application.Services.Impl;
using backend.Application.Validators;
using backend.DataAccess;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace backend.Application
{
    [ExcludeFromCodeCoverage]
    public static class Extensions
    {
        public static IServiceCollection AddContexts(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSubscrierContext(configuration);

            return services;
        }
        public static IServiceProvider AddMigrations(this IServiceProvider serviceProvider)
        {
            serviceProvider.AddAutoMigration();

            return serviceProvider;
        }
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ISubscriberService, SubscriberService>();
            services.AddRepositories();

            return services;
        }

        public static IServiceCollection AddValidators(this IServiceCollection services)
        {

            services.AddAutoMapper(typeof(SubscriberMapper));
            services.AddValidatorsFromAssemblyContaining<NewSubscriberModelValidator>();
            services.AddFluentValidationAutoValidation();
            return services;
        }
    }
}
