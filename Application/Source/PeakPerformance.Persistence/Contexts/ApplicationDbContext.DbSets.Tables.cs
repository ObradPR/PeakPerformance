using Microsoft.EntityFrameworkCore;
using PeakPerformance.Domain.Entities.Application;

namespace PeakPerformance.Persistence.Contexts;

public partial class ApplicationDbContext
{
    // Tables

    public virtual DbSet<ErrorLog> ErrorLogs { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    public virtual DbSet<UserActivityLog> UserActivityLogs { get; set; }

    public virtual DbSet<UserMeasurementPreference> UserMeasurementPreferences { get; set; }

    public virtual DbSet<Weight> Weights { get; set; }

    public virtual DbSet<BodyMeasurement> BodyMeasurements { get; set; }
}