namespace PeakPerformance.Domain.Interfaces;

public interface IIdentityUser
{
    long Id { get; }

    string Email { get; }

    string Username { get; }

    IEnumerable<eSystemRole> Roles { get; }

    bool IsAuthenticated { get; }

    bool HasRole(IEnumerable<eSystemRole> roles);
}