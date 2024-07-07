using PeakPerformance.Common;
using System.Security.Claims;

namespace PeakPerformance.WebApi.Extensions;

public static partial class Extensions
{
    public static long GetId(this IEnumerable<Claim> claims)
        => long.Parse(GetClaim(claims, Constants.CLAIM_ID));

    public static string GetEmail(this IEnumerable<Claim> claims)
        => GetClaim(claims, Constants.CLAIM_EMAIL);

    public static string GetUsername(this IEnumerable<Claim> claims)
        => GetClaim(claims.ToList(), Constants.CLAIM_USERNAME);

    public static List<string> GetRoles(this IEnumerable<Claim> claims)
        => GetClaim(claims, Constants.CLAIM_ROLES).Split(",").ToList();

    private static string GetClaim(IEnumerable<Claim> claims, string claimType)
        => claims.SingleOrDefault(_ => _.Type.Equals(claimType))?.Value ?? string.Empty;
}