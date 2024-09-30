namespace PeakPerformance.Domain.Entities._Base.Interfaces;

public interface IConfigurableEntity
{
    void Configure(ModelBuilder builder);
}