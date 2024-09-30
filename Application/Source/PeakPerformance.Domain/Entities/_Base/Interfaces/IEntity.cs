namespace PeakPerformance.Domain.Entities._Base.Interfaces;

public interface IEntity<TKey>
    where TKey : struct
{
    TKey Id { get; set; }
}