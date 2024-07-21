using Microsoft.EntityFrameworkCore;
using PeakPerformance.Domain.Entities.Application;
using PeakPerformance.Domain.Entities.Application_lu;
using PeakPerformance.Domain.Entities.Audits;

namespace PeakPerformance.Persistence.Contexts;

public partial class ApplicationDbContext
{
    // Tables

    public virtual DbSet<ErrorLog> ErrorLogs { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    public virtual DbSet<UserActivityLog> UserActivityLogs { get; set; }

    public virtual DbSet<UserMeasurementPreference> UserMeasurementPreferences { get; set; }

    // Lookup Tables

    public virtual DbSet<SystemRole> SystemRoles { get; set; }

    public virtual DbSet<ActionType> ActionTypes { get; set; }

    public virtual DbSet<MeasurementUnit> MeasurementsUnits { get; set; }

    // Audit Tables

    public virtual DbSet<User_aud> Users_aud { get; set; }

    public virtual DbSet<UserRole_aud> UserRoles_aud { get; set; }

    public virtual DbSet<UserMeasurementPreference_aud> UserMeasurementPreferences_aud { get; set; }
}