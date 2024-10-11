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
using PeakPerformance.Common;
using PeakPerformance.Common.Extensions;
using PeakPerformance.Common.Interfaces;
using PeakPerformance.Domain.Repositories;
using PeakPerformance.Infrastructure.Logger;
using PeakPerformance.Infrastructure.Storage.Interfaces;
using PeakPerformance.Infrastructure.Storage.Services;
using PeakPerformance.Persistence.Contexts;
using PeakPerformance.Persistence.Repositories;
using System.Text;

namespace PeakPerformance.DependencyInjection;

public static partial class Extensions
{
    public static IServiceCollection AllApplicationServices(this IServiceCollection services)
    {
        var secrets = CreateSecretConfiguration();

        PersistenceServices(services);
        ApplicationServices(services, secrets);
        ApplicationIdentityService(services, secrets);
        InfrastructureServices(services, secrets);
        IntegrationServices(services, secrets);

        return services;
    }

    private static IServiceCollection PersistenceServices(IServiceCollection services)
    {
        services.AddDbContext<ApplicationDbContext>(
            opt => opt.UseSqlServer(Settings.ConnectionString));

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

    private static IServiceCollection InfrastructureServices(IServiceCollection services, IConfiguration secrets)
    {
        services.AddTransient<IExceptionLogger, DbExceptionLogger>();

        services.AddSingleton<ICloudinaryService>(new CloudinaryService(secrets["Cloudinary:ApiCredentials"]!));

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