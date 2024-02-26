using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace TaskManagerAPI.Application;

public static class ServiceRegistrations
{
    public static void AddApplicationServices(this IServiceCollection service)
    {
        
      //  service.AddMediatR(typeof(ServiceRegistrations));
      service.AddMediatR(cfg=>cfg.RegisterServicesFromAssemblies(typeof(ServiceRegistrations).Assembly));

    }
}