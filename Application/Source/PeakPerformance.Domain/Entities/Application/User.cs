﻿using PeakPerformance.Domain.Entities._Base;

namespace PeakPerformance.Domain.Entities.Application;

public class User : AuditableEntity
{
    public string FirstName { get; set; } = string.Empty;

    public string? MiddleName { get; set; }

    public string LastName { get; set; } = string.Empty;

    public string Username { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public DateTime DateOfBirth { get; set; }

    public string PhoneNumber { get; set; } = string.Empty;

    public bool ReceiveAppNews { get; set; } = false;

    // Relationships

    public virtual ICollection<UserRole> UserRoles { get; set; } = [];

    public virtual ICollection<UserActivityLog> UserActivityLogs { get; set; } = [];

    public virtual ICollection<UserMeasurementPreference> UserMeasurementPreferences { get; set; } = [];

    public virtual ICollection<Weight> Weights { get; set; } = [];

    public virtual ICollection<BodyMeasurement> BodyMeasurements { get; set; } = [];
}