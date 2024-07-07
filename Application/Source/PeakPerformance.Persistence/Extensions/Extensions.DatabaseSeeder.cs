using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PeakPerformance.Common.Enums;
using PeakPerformance.Common.Extensions;
using PeakPerformance.Common.Interfaces;
using PeakPerformance.Domain.Entities.Application_lu;
using PeakPerformance.Persistence.Enums;

namespace PeakPerformance.Persistence.Extensions;

public static partial class Extensions
{
    public static async Task SeedData<TContext>(this IServiceProvider serviceProvider)
        where TContext : DbContext
    {
        var scope = serviceProvider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<TContext>();

        try
        {
            // Ensure database is created
            await context.EnsureDatabaseMigratedAsync();

            // Seed data
            await SeedSystemRolesAsync(context);
            await SeedActionTypesAsync(context);
        }
        catch (Exception ex)
        {
            context.DetachAllTrackedChanges();

            IExceptionLogger logger = scope.ServiceProvider.GetService<IExceptionLogger>()!;

            await logger?.LogExceptionAsync(ex)!;
        }
    }

    private static async Task SeedSystemRolesAsync<TContext>(TContext context)
        where TContext : DbContext
    {
        if (await context.Set<SystemRole>().AnyAsync())
            return;

        using (var transaction = context.Database.BeginTransaction())
        {
            context.SetIdentityInsert(typeof(SystemRole));

            await context.Set<SystemRole>().AddRangeAsync(
                new SystemRole { Id = eSystemRole.Admin.ToInt(), Name = eSystemRole.Admin.GetDescription() },
                new SystemRole { Id = eSystemRole.User.ToInt(), Name = eSystemRole.User.GetDescription() },
                new SystemRole { Id = eSystemRole.Guest.ToInt(), Name = eSystemRole.Guest.GetDescription() }
            );

            // Save all changes
            await context.SaveChangesAsync();

            context.SetIdentityInsert(typeof(SystemRole), true, eIdentitySwitch.Off);

            transaction.Commit();
        }
    }

    private static async Task SeedActionTypesAsync<TContext>(TContext context)
        where TContext : DbContext
    {
        if (await context.Set<ActionType>().AnyAsync())
            return;

        using (var transaction = context.Database.BeginTransaction())
        {
            context.SetIdentityInsert(typeof(ActionType));

            await context.Set<ActionType>().AddRangeAsync(
                new ActionType { Id = eActionType.Create.ToInt(), Name = eActionType.Create.GetDescription() },
                new ActionType { Id = eActionType.Update.ToInt(), Name = eActionType.Update.GetDescription() },
                new ActionType { Id = eActionType.Delete.ToInt(), Name = eActionType.Delete.GetDescription() },
                new ActionType { Id = eActionType.Login.ToInt(), Name = eActionType.Login.GetDescription() },
                new ActionType { Id = eActionType.Logout.ToInt(), Name = eActionType.Logout.GetDescription() }
            );

            // Save all changes
            await context.SaveChangesAsync();

            context.SetIdentityInsert(typeof(ActionType), true, eIdentitySwitch.Off);

            transaction.Commit();
        }
    }
}