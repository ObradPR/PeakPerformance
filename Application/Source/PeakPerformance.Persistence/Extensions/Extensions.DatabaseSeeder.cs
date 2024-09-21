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
            await SeedSocialMediaPlatformsAsync(context);
            await SeedInjuryTypesAsync(context);
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
                new SystemRole { Id = (int)eSystemRole.Admin, Name = eSystemRole.Admin.GetEnumDescription() },
                new SystemRole { Id = (int)eSystemRole.User, Name = eSystemRole.User.GetEnumDescription() },
                new SystemRole { Id = (int)eSystemRole.Guest, Name = eSystemRole.Guest.GetEnumDescription() }
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
                new ActionType { Id = (int)eActionType.Create, Name = eActionType.Create.GetEnumDescription() },
                new ActionType { Id = (int)eActionType.Update, Name = eActionType.Update.GetEnumDescription() },
                new ActionType { Id = (int)eActionType.Delete, Name = eActionType.Delete.GetEnumDescription() },
                new ActionType { Id = (int)eActionType.Deactivate, Name = eActionType.Deactivate.GetEnumDescription() },
                new ActionType { Id = (int)eActionType.Signup, Name = eActionType.Signup.GetEnumDescription() },
                new ActionType { Id = (int)eActionType.Signin, Name = eActionType.Signin.GetEnumDescription() },
                new ActionType { Id = (int)eActionType.Signout, Name = eActionType.Signout.GetEnumDescription() }
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
                new MeasurementUnit { Id = (int)eMeasurementUnit.Kilograms, Name = eMeasurementUnit.Kilograms.GetEnumDescription() },
               new MeasurementUnit { Id = (int)eMeasurementUnit.Pounds, Name = eMeasurementUnit.Pounds.GetEnumDescription() },
               new MeasurementUnit { Id = (int)eMeasurementUnit.Centimeters, Name = eMeasurementUnit.Centimeters.GetEnumDescription() },
               new MeasurementUnit { Id = (int)eMeasurementUnit.Inches, Name = eMeasurementUnit.Inches.GetEnumDescription() }
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
                new TrainingGoal { Id = (int)eTrainingGoal.Strength, Name = eTrainingGoal.Strength.GetEnumDescription() },
                new TrainingGoal { Id = (int)eTrainingGoal.Bulking, Name = eTrainingGoal.Bulking.GetEnumDescription() },
                new TrainingGoal { Id = (int)eTrainingGoal.Cutting, Name = eTrainingGoal.Cutting.GetEnumDescription() },
                new TrainingGoal { Id = (int)eTrainingGoal.Cardio, Name = eTrainingGoal.Cardio.GetEnumDescription() },
                new TrainingGoal { Id = (int)eTrainingGoal.Explosivness, Name = eTrainingGoal.Explosivness.GetEnumDescription() },
                new TrainingGoal { Id = (int)eTrainingGoal.Endurance, Name = eTrainingGoal.Endurance.GetEnumDescription() },
                new TrainingGoal { Id = (int)eTrainingGoal.Flexibility, Name = eTrainingGoal.Flexibility.GetEnumDescription() },
                new TrainingGoal { Id = (int)eTrainingGoal.Balance, Name = eTrainingGoal.Balance.GetEnumDescription() },
                new TrainingGoal { Id = (int)eTrainingGoal.Agility, Name = eTrainingGoal.Agility.GetEnumDescription() }
            );

            // Save all changes
            await context.SaveChangesAsync();

            context.SetIdentityInsert<TContext, TrainingGoal>(eIdentitySwitch.Off);

            transaction.Commit();
        }
    }

    private static async Task SeedSocialMediaPlatformsAsync<TContext>(TContext context)
        where TContext : DbContext
    {
        if (await context.Set<SocialMediaPlatform>().AnyAsync())
            return;

        using (var transaction = context.Database.BeginTransaction())
        {
            context.SetIdentityInsert<TContext, SocialMediaPlatform>();

            await context.Set<SocialMediaPlatform>().AddRangeAsync(
                new SocialMediaPlatform { Id = (int)eSocialMediaPlatform.Facebook, Name = eSocialMediaPlatform.Facebook.GetEnumDescription() },
                new SocialMediaPlatform { Id = (int)eSocialMediaPlatform.Twitter, Name = eSocialMediaPlatform.Twitter.GetEnumDescription() },
                new SocialMediaPlatform { Id = (int)eSocialMediaPlatform.Instagram, Name = eSocialMediaPlatform.Instagram.GetEnumDescription() },
                new SocialMediaPlatform { Id = (int)eSocialMediaPlatform.LinkedIn, Name = eSocialMediaPlatform.LinkedIn.GetEnumDescription() },
                new SocialMediaPlatform { Id = (int)eSocialMediaPlatform.YouTube, Name = eSocialMediaPlatform.YouTube.GetEnumDescription() },
                new SocialMediaPlatform { Id = (int)eSocialMediaPlatform.TikTok, Name = eSocialMediaPlatform.TikTok.GetEnumDescription() },
                new SocialMediaPlatform { Id = (int)eSocialMediaPlatform.Pinterest, Name = eSocialMediaPlatform.Pinterest.GetEnumDescription() },
                new SocialMediaPlatform { Id = (int)eSocialMediaPlatform.Snapchat, Name = eSocialMediaPlatform.Snapchat.GetEnumDescription() },
                new SocialMediaPlatform { Id = (int)eSocialMediaPlatform.WhatsApp, Name = eSocialMediaPlatform.WhatsApp.GetEnumDescription() },
                new SocialMediaPlatform { Id = (int)eSocialMediaPlatform.Telegram, Name = eSocialMediaPlatform.Telegram.GetEnumDescription() },
                new SocialMediaPlatform { Id = (int)eSocialMediaPlatform.Reddit, Name = eSocialMediaPlatform.Reddit.GetEnumDescription() }
            );

            // Save all changes
            await context.SaveChangesAsync();

            context.SetIdentityInsert<TContext, SocialMediaPlatform>(eIdentitySwitch.Off);

            transaction.Commit();
        }
    }

    private static async Task SeedInjuryTypesAsync<TContext>(TContext context)
        where TContext : DbContext
    {
        if (await context.Set<InjuryType>().AnyAsync())
            return;

        using (var transaction = context.Database.BeginTransaction())
        {
            context.SetIdentityInsert<TContext, InjuryType>();

            await context.Set<InjuryType>().AddRangeAsync(
                new InjuryType { Id = (int)eInjuryType.KneeInjury, Name = eInjuryType.KneeInjury.GetEnumDescription() },
                new InjuryType { Id = (int)eInjuryType.ShoulderInjury, Name = eInjuryType.ShoulderInjury.GetEnumDescription() },
                new InjuryType { Id = (int)eInjuryType.BackInjury, Name = eInjuryType.BackInjury.GetEnumDescription() },
                new InjuryType { Id = (int)eInjuryType.ElbowInjury, Name = eInjuryType.ElbowInjury.GetEnumDescription() },
                new InjuryType { Id = (int)eInjuryType.WristInjury, Name = eInjuryType.WristInjury.GetEnumDescription() },
                new InjuryType { Id = (int)eInjuryType.AnkleInjury, Name = eInjuryType.AnkleInjury.GetEnumDescription() },
                new InjuryType { Id = (int)eInjuryType.HipInjury, Name = eInjuryType.HipInjury.GetEnumDescription() },
                new InjuryType { Id = (int)eInjuryType.NeckInjury, Name = eInjuryType.NeckInjury.GetEnumDescription() },
                new InjuryType { Id = (int)eInjuryType.Asthma, Name = eInjuryType.Asthma.GetEnumDescription() },
                new InjuryType { Id = (int)eInjuryType.HeartCondition, Name = eInjuryType.HeartCondition.GetEnumDescription() },
                new InjuryType { Id = (int)eInjuryType.Diabetes, Name = eInjuryType.Diabetes.GetEnumDescription() },
                new InjuryType { Id = (int)eInjuryType.Arthritis, Name = eInjuryType.Arthritis.GetEnumDescription() },
                new InjuryType { Id = (int)eInjuryType.HighBloodPressure, Name = eInjuryType.HighBloodPressure.GetEnumDescription() },
                new InjuryType { Id = (int)eInjuryType.LowBloodPressure, Name = eInjuryType.LowBloodPressure.GetEnumDescription() },
                new InjuryType { Id = (int)eInjuryType.Pregnancy, Name = eInjuryType.Pregnancy.GetEnumDescription() },
                new InjuryType { Id = (int)eInjuryType.ChronicFatigue, Name = eInjuryType.ChronicFatigue.GetEnumDescription() },
                new InjuryType { Id = (int)eInjuryType.Scoliosis, Name = eInjuryType.Scoliosis.GetEnumDescription() },
                new InjuryType { Id = (int)eInjuryType.PlantarFasciitis, Name = eInjuryType.PlantarFasciitis.GetEnumDescription() },
                new InjuryType { Id = (int)eInjuryType.Tendinitis, Name = eInjuryType.Tendinitis.GetEnumDescription() },
                new InjuryType { Id = (int)eInjuryType.CarpalTunnelSyndrome, Name = eInjuryType.CarpalTunnelSyndrome.GetEnumDescription() },
                new InjuryType { Id = (int)eInjuryType.ChestInjury, Name = eInjuryType.ChestInjury.GetEnumDescription() },
                new InjuryType { Id = (int)eInjuryType.BicepInjury, Name = eInjuryType.BicepInjury.GetEnumDescription() },
                new InjuryType { Id = (int)eInjuryType.TricepInjury, Name = eInjuryType.TricepInjury.GetEnumDescription() },
                new InjuryType { Id = (int)eInjuryType.QuadInjury, Name = eInjuryType.QuadInjury.GetEnumDescription() },
                new InjuryType { Id = (int)eInjuryType.HamstringInjury, Name = eInjuryType.HamstringInjury.GetEnumDescription() }
            );

            // Save all changes
            await context.SaveChangesAsync();

            context.SetIdentityInsert<TContext, InjuryType>(eIdentitySwitch.Off);

            transaction.Commit();
        }
    }
}