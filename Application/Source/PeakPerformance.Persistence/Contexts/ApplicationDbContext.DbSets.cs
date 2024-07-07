using Microsoft.EntityFrameworkCore;
using PeakPerformance.Domain.Entities.Application;
using PeakPerformance.Domain.Entities.Application_lu;

namespace PeakPerformance.Persistence.Contexts;

public partial class ApplicationDbContext
{
    // Tables

    public virtual DbSet<ErrorLog> ErrorLogs { get; set; }

    // Lookup Tables

    public virtual DbSet<SystemRole> SystemRoles { get; set; }

    public virtual DbSet<ActionType> ActionTypes { get; set; }
}