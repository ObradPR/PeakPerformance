using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PeakPerformance.Common.Interfaces;
using PeakPerformance.Domain.Repositories;
using PeakPerformance.Infrastructure.Logger;
using PeakPerformance.Persistence.Contexts;
using PeakPerformance.Persistence.Repositories;

namespace PeakPerformance.DependencyInjection;

public static partial class Extensions
{
    public static IServiceCollection AllApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        PersistenceServices(services, configuration);
        //ApplicationServices(services);
        //ApplicationIdentityService(services, configuration);
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

    private static IServiceCollection InfrastructureServices(IServiceCollection services)
    {
        services.AddTransient<IExceptionLogger, DbExceptionLogger>();

        return services;
    }
}