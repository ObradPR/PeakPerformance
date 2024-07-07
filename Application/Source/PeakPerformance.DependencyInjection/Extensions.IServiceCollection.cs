using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using PeakPerformance.Application.BusinessLogic._Base;
using PeakPerformance.Application.BusinessLogic._Behaviors;
using PeakPerformance.Application.Identity.Interfaces;
using PeakPerformance.Application.Identity.Services;
using PeakPerformance.Common.Interfaces;
using PeakPerformance.Domain.Repositories;
using PeakPerformance.Infrastructure.Logger;
using PeakPerformance.Persistence.Contexts;
using PeakPerformance.Persistence.Repositories;
using System.Text;

namespace PeakPerformance.DependencyInjection;

public static partial class Extensions
{
    public static IServiceCollection AllApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        PersistenceServices(services, configuration);
        ApplicationServices(services);
        ApplicationIdentityService(services, configuration);
        InfrastructureServices(services);

        return services;
    }

    private static IServiceCollection PersistenceServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(
            opt => opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }

    private static IServiceCollection ApplicationServices(IServiceCollection services)
    {
        var assembly = typeof(BaseCommand<>).Assembly;

        services.AddMediatR(config => config.RegisterServicesFromAssembly(assembly));
        services.AddValidatorsFromAssembly(assembly);
        services.AddAutoMapper(assembly);

        ApplicationPipelineBehaviors(services);

        return services;
    }

    private static IServiceCollection ApplicationIdentityService(IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(opt =>
        {
            opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(opt =>
        {
            opt.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = configuration["Jwt:Issuer"],
                ValidAudience = configuration["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!)),
                ClockSkew = TimeSpan.Zero
            };
        });

        services.AddScoped<IUserManager, UserManager>();
        services.AddScoped<ITokenService, TokenService>();

        return services;
    }

    private static IServiceCollection InfrastructureServices(IServiceCollection services)
    {
        services.AddTransient<IExceptionLogger, DbExceptionLogger>();

        return services;
    }

    private static IServiceCollection ApplicationPipelineBehaviors(IServiceCollection services)
    {
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceMonitoringBehavior<,>));

        return services;
    }
}