using System.Net.Mail;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TaskManagerAPI.Application.Abstractions.Services;
using TaskManagerAPI.Application.Abstractions.Token;
using TaskManagerAPI.Application.Repositories;
using TaskManagerAPI.Domain.Entities;
using TaskManagerAPI.Infrastructure.Services;
using TaskManagerAPI.Infrastructure.Services.Token;
using TaskManagerAPI.Persistence.Context;
using TaskManagerAPI.Persistence.Repositories;
using TaskManagerAPI.Persistence.Services;

namespace TaskManagerAPI.Persistence.ServicesRegistration;

public static class ServiceRegistration
{
    public static void AddServicesRegistration(this IServiceCollection service)
    {
        service.AddDbContext<TaskManagerDbContext>(options =>
            options.UseNpgsql(Configuration.ConnectionString));
        service.AddScoped<ITeamRepository, TeamRepository>();
        service.AddScoped<IUserTaskRepository, UserTaskRepository>();
        service.AddScoped<ITokenHandler, TokenHandler>();
        service.AddIdentity<User, UserRole>(options =>
        {
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;
            options.Password.RequiredLength = 3;
            options.Password.RequiredUniqueChars = 0;
            
        } ).AddEntityFrameworkStores<TaskManagerDbContext>()
            .AddDefaultTokenProviders();//burası GenereteResetToken ı kullanarak reset token üretmemizi sağlayan servistir.
        

        service.AddScoped<IUserService,UserService>();
        service.AddScoped<IAuthService,AuthService>();
        service.AddScoped<IMailService,MailService>();
    }
}