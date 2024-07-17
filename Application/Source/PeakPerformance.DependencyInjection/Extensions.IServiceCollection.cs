using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using PeakPerformance.AbstractAPI.Handlers;
using PeakPerformance.Application.BusinessLogic._Base;
using PeakPerformance.Application.BusinessLogic._Behaviors;
using PeakPerformance.Application.Identity.Interfaces;
using PeakPerformance.Application.Identity.Services;
using PeakPerformance.Application.Interfaces;
using PeakPerformance.Application.Services;
using PeakPerformance.Common.Extensions;
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
        var secrets = CreateSecretConfiguration();

        PersistenceServices(services, configuration);
        ApplicationServices(services, secrets);
        ApplicationIdentityService(services, secrets);
        InfrastructureServices(services);
        IntegrationServices(services, secrets);

        return services;
    }

    private static IServiceCollection PersistenceServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(
            opt => opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }

    private static IServiceCollection ApplicationServices(IServiceCollection services, IConfiguration secrets)
    {
        var assembly = typeof(BaseCommand<>).Assembly;

        services.AddMediatR(config => config.RegisterServicesFromAssembly(assembly));
        services.AddValidatorsFromAssembly(assembly);
        services.AddAutoMapper(assembly);
        services.AddSingleton<IEmailService>(provider =>
            new EmailService(
                secrets["SmtpSettings:Server"]!,
                secrets["SmtpSettings:Port"]!.ToInt(),
                secrets["SmtpSettings:Username"]!,
                secrets["SmtpSettings:Password"]!
            )
        );
        services.AddScoped<IVerificationCodeService, VerificationCodeService>();

        ApplicationPipelineBehaviors(services);

        return services;
    }

    private static IServiceCollection ApplicationIdentityService(IServiceCollection services, IConfiguration secrets)
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
                ValidIssuer = secrets["Jwt:Issuer"],
                ValidAudience = secrets["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secrets["Jwt:Key"]!)),
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

    private static IServiceCollection IntegrationServices(IServiceCollection services, IConfiguration secrets)
    {
        services.AddSingleton(new EmailValidation(secrets["AbstractAPI:ApiCredentials"]!));

        return services;
    }
}