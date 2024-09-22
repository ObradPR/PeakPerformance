namespace PeakPerformance.Domain.Entities._Base;

public abstract class Entity_lu : _BaseEntity, IEntity_lu
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;
}