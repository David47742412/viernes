using System.Security.Claims;
using Dulcepastel.Models.usuario;
using Dulcepastel.Models.utility.jwt;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Dulcepastel.Models.utility.cookie;

public static class GetCookie
{
    public static async Task<Usuario> GetData(HttpContext context)
    {
        var authenticationTicket =
            await context.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        var tokenValue = authenticationTicket.Principal?.FindFirst(ClaimTypes.Name)?.Value;
        var identity = new ClaimsIdentity();
        identity.AddClaim(new Claim("__Token", tokenValue!));
        return JwtConfig.ValidateToken(identity)!;
    }
}