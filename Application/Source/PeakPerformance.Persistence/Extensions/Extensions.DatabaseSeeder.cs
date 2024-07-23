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
            await SeedMeasurementUnitsAsync(context);
            await SeedTrainingGoalsAsync(context);
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
            context.SetIdentityInsert<TContext, SystemRole>();

            await context.Set<SystemRole>().AddRangeAsync(
                new SystemRole { Id = eSystemRole.Admin.ToInt(), Name = eSystemRole.Admin.GetEnumDescription() },
                new SystemRole { Id = eSystemRole.User.ToInt(), Name = eSystemRole.User.GetEnumDescription() },
                new SystemRole { Id = eSystemRole.Guest.ToInt(), Name = eSystemRole.Guest.GetEnumDescription() }
            );

            // Save all changes
            await context.SaveChangesAsync();

            context.SetIdentityInsert<TContext, SystemRole>(eIdentitySwitch.Off);

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
            context.SetIdentityInsert<TContext, ActionType>();

            await context.Set<ActionType>().AddRangeAsync(
                new ActionType { Id = eActionType.Create.ToInt(), Name = eActionType.Create.GetEnumDescription() },
                new ActionType { Id = eActionType.Update.ToInt(), Name = eActionType.Update.GetEnumDescription() },
                new ActionType { Id = eActionType.Delete.ToInt(), Name = eActionType.Delete.GetEnumDescription() },
                new ActionType { Id = eActionType.Deactivate.ToInt(), Name = eActionType.Deactivate.GetEnumDescription() },
                new ActionType { Id = eActionType.Signup.ToInt(), Name = eActionType.Signup.GetEnumDescription() },
                new ActionType { Id = eActionType.Signin.ToInt(), Name = eActionType.Signin.GetEnumDescription() },
                new ActionType { Id = eActionType.Signout.ToInt(), Name = eActionType.Signout.GetEnumDescription() }
            );

            // Save all changes
            await context.SaveChangesAsync();

            context.SetIdentityInsert<TContext, ActionType>(eIdentitySwitch.Off);

            transaction.Commit();
        }
    }

    private static async Task SeedMeasurementUnitsAsync<TContext>(TContext context)
        where TContext : DbContext
    {
        if (await context.Set<MeasurementUnit>().AnyAsync())
            return;

        using (var transaction = context.Database.BeginTransaction())
        {
            context.SetIdentityInsert<TContext, MeasurementUnit>();

            await context.Set<MeasurementUnit>().AddRangeAsync(
                new MeasurementUnit { Id = eMeasurementUnit.Kilograms.ToInt(), Name = eMeasurementUnit.Kilograms.GetEnumDescription() },
               new MeasurementUnit { Id = eMeasurementUnit.Pounds.ToInt(), Name = eMeasurementUnit.Pounds.GetEnumDescription() },
               new MeasurementUnit { Id = eMeasurementUnit.Centimeters.ToInt(), Name = eMeasurementUnit.Centimeters.GetEnumDescription() },
               new MeasurementUnit { Id = eMeasurementUnit.Inches.ToInt(), Name = eMeasurementUnit.Inches.GetEnumDescription() }
            );

            // Save all changes
            await context.SaveChangesAsync();

            context.SetIdentityInsert<TContext, MeasurementUnit>(eIdentitySwitch.Off);

            transaction.Commit();
        }
    }

    private static async Task SeedTrainingGoalsAsync<TContext>(TContext context)
        where TContext : DbContext
    {
        if (await context.Set<TrainingGoal>().AnyAsync())
            return;

        using (var transaction = context.Database.BeginTransaction())
        {
            context.SetIdentityInsert<TContext, TrainingGoal>();

            await context.Set<TrainingGoal>().AddRangeAsync(
                new TrainingGoal { Id = eTrainingGoal.Strength.ToInt(), Name = eTrainingGoal.Strength.GetEnumDescription() },
                new TrainingGoal { Id = eTrainingGoal.Bulking.ToInt(), Name = eTrainingGoal.Bulking.GetEnumDescription() },
                new TrainingGoal { Id = eTrainingGoal.Cutting.ToInt(), Name = eTrainingGoal.Cutting.GetEnumDescription() },
                new TrainingGoal { Id = eTrainingGoal.Cardio.ToInt(), Name = eTrainingGoal.Cardio.GetEnumDescription() },
                new TrainingGoal { Id = eTrainingGoal.Explosivness.ToInt(), Name = eTrainingGoal.Explosivness.GetEnumDescription() },
                new TrainingGoal { Id = eTrainingGoal.Endurance.ToInt(), Name = eTrainingGoal.Endurance.GetEnumDescription() },
                new TrainingGoal { Id = eTrainingGoal.Flexibility.ToInt(), Name = eTrainingGoal.Flexibility.GetEnumDescription() },
                new TrainingGoal { Id = eTrainingGoal.Balance.ToInt(), Name = eTrainingGoal.Balance.GetEnumDescription() },
                new TrainingGoal { Id = eTrainingGoal.Agility.ToInt(), Name = eTrainingGoal.Agility.GetEnumDescription() }
            );

            // Save all changes
            await context.SaveChangesAsync();

            context.SetIdentityInsert<TContext, TrainingGoal>(eIdentitySwitch.Off);

            transaction.Commit();
        }
    }
}