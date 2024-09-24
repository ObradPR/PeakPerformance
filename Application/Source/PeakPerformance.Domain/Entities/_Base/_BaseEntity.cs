﻿using System.ComponentModel.DataAnnotations.Schema;

namespace PeakPerformance.Domain.Entities._Base;

public abstract class _BaseEntity
{
    [NotMapped]
    public virtual bool ShouldPluralize => true;
}