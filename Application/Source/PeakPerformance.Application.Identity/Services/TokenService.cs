using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PeakPerformance.Application.Identity.Interfaces;
using PeakPerformance.Common;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;

namespace PeakPerformance.Application.Identity.Services;

public class TokenService(IConfiguration configuration) : ITokenService
{
    private readonly IConfiguration _configuration = configuration;

    public string GenerateJwtToken(long userId, string[] roles, string fullName, string email, string username)
    {
        var tokenHandler = new JwtSecurityTokenHandler();

        var jwtSecrets = new
        {
            Key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!),
            Issuer = _configuration["Jwt:Issuer"],
            Audience = _configuration["Jwt:Audience"]
        };

        var claims = new List<Claim>
        {
            new(Constants.CLAIM_ID, userId.ToString()),
            new(Constants.CLAIM_USERNAME, username),
            new(Constants.CLAIM_FULLNAME, Regex.Replace(fullName, @"\s{2}", " ")),
            new(Constants.CLAIM_EMAIL, email),
            new(Constants.CLAIM_ISSUER, jwtSecrets.Issuer!)
        };

        claims.AddRange(roles.Select(_ => new Claim(Constants.CLAIM_ROLES, _)));

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Issuer = jwtSecrets.Issuer,
            Audience = jwtSecrets.Audience,
            Expires = DateTime.UtcNow.AddDays(Constants.TOKEN_EXPIRATION_TIME),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(jwtSecrets.Key), SecurityAlgorithms.HmacSha512Signature),
            Claims = claims.ToDictionary(_ => _.Type, _ => (object)_.Value)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}