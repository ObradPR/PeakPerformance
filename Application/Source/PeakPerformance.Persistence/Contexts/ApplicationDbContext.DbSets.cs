using Microsoft.EntityFrameworkCore;
using PeakPerformance.Domain.Entities.Application;

namespace PeakPerformance.Persistence.Contexts;

public partial class ApplicationDbContext
{
    public virtual DbSet<ErrorLog> ErrorLogs { get; set; }
}