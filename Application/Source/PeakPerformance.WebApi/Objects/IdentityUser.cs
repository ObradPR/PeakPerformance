using PeakPerformance.Common.Enums;
using PeakPerformance.Common.Extensions;
using PeakPerformance.Common.Interfaces;
using PeakPerformance.WebApi.Extensions;

namespace PeakPerformance.WebApi.Objects;

public class IdentityUser(IHttpContextAccessor httpContextAccessor) : IIdentityUser
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
    private bool _isParsed = false;
    private long _id;
    private string _username = string.Empty;
    private string _email = string.Empty;
    private List<eSystemRole> _roles = [];
    private bool _isAuthenticated;

    public long Id
    {
        get
        {
            ParseIdentity();
            return _id;
        }
    }

    public string Email
    {
        get
        {
            ParseIdentity();
            return _email;
        }
    }

    public string Username
    {
        get
        {
            ParseIdentity();
            return _username;
        }
    }

    public IEnumerable<eSystemRole> Roles
    {
        get
        {
            ParseIdentity();
            return _roles;
        }
    }

    public bool IsAuthenticated
    {
        get
        {
            ParseIdentity();
            return _isAuthenticated;
        }
    }

    public bool HasRole(IEnumerable<eSystemRole> roles)
    {
        return roles.Any(Roles.Contains);
    }

    private void ParseIdentity()
    {
        if (!_isParsed)
        {
            var user = _httpContextAccessor?.HttpContext?.User;

            if (user is null)
                return;

            _isAuthenticated = user.Identity!.IsAuthenticated;

            if (_isAuthenticated)
            {
                _id = user.Claims.GetId();
                _email = user.Claims.GetEmail();
                _username = user.Claims.GetUsername();
                _roles = user.Claims.GetRoles().ParseEnumList<eSystemRole>();
            }
        }

        _isParsed = true;
    }
}