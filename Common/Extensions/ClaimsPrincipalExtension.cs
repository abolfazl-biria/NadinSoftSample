using Common.Configurations;
using Common.Dtos;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Common.Extensions;

public static class ClaimsPrincipalExtension
{
    public static int? GetUserId(this ClaimsPrincipal principal) =>
        principal.FindFirst(ClaimTypes.NameIdentifier)?.Value.ToIntNull();

    public static string? GetUserName(this ClaimsPrincipal principal) =>
        principal.FindFirst(ClaimTypes.Name)?.Value;

    public static List<string> GetRoles(this ClaimsPrincipal principal) =>
        principal.FindAll(ClaimTypes.Role).Select(x => x.Value).ToList();

    public static UserInfoDto GetUserInfo(this ClaimsPrincipal principal) =>
        new()
        {
            IsAdmin = principal.IsInRole(UserRoles.Admin),
            UserId = principal.GetUserId()!.Value
        };

    public static JwtSecurityToken GetToken(IEnumerable<Claim> authClaims)
    {
        var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtConfig.Secret));

        var token = new JwtSecurityToken(
            issuer: JwtConfig.ValidIssuer,
            audience: JwtConfig.ValidAudience,
            expires: DateTime.Now.AddDays(JwtConfig.ExpireDays),
            claims: authClaims,
            signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256));

        return token;
    }
}