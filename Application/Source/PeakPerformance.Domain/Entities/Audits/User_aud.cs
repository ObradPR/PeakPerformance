using PeakPerformance.Domain.Entities._Base;
using PeakPerformance.Domain.Entities.Application_lu;

namespace PeakPerformance.Domain.Entities.Audits;

public class User_aud : Audit
{
    public long? Id { get; set; }
}