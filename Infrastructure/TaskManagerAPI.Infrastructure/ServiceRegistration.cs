using Microsoft.Extensions.DependencyInjection;
using TaskManagerAPI.Application.Abstractions.Services.Configurations;
using TaskManagerAPI.Infrastructure.Configuration;

namespace TaskManagerAPI.Infrastructure;

public static class ServiceRegistration
{
    public static void AddInfrastructureServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IAuthorizeService, AuthorizeService>();
    }
}