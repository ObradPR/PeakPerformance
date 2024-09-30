namespace PeakPerformance.Domain.Entities._Base.Interfaces;

public interface IBaseDomain<TKey> : IEntity<TKey>
    where TKey : struct
{ }