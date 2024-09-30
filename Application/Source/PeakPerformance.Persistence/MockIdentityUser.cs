using PeakPerformance.Common.Enums;
using PeakPerformance.Common.Interfaces;

namespace PeakPerformance.Common;

public class MockIdentityUser : IIdentityUser
{
    public long Id { get; set; } = Constants.SYSTEM_USER_ID;

    public string Email { get; set; } = Constants.SYSTEM_USER_EMAIL;

    public string Username { get; set; } = Constants.SYSTEM_USER_USERNAME;

    public IEnumerable<eSystemRole> Roles { get; set; } = [eSystemRole.Admin];

    public bool IsAuthenticated { get; set; } = true;

    public bool HasRole(IEnumerable<eSystemRole> roles)
    {
        throw new NotImplementedException();
    }
}