using GalaxyApp.Helpers.Abstractions;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace GalaxyApp.Security
{
    public class CustomAuthenticayionProvider : AuthenticationStateProvider
    {
        private const string EXPIRATION_CLAIM = "exp";
        private readonly IBrowserStorageHelper storageHelper;

        public CustomAuthenticayionProvider(
            IBrowserStorageHelper storageHelper)
        {
            this.storageHelper = storageHelper;
        }

        private bool IsTokenExpired(JwtSecurityToken token)
        {
            var claim = token.Claims
                .First(claim => claim.Type == EXPIRATION_CLAIM)
                .Value;
            var ticks = long.Parse(claim);
            DateTime tokenExpDate = DateTimeOffset.FromUnixTimeSeconds(ticks).UtcDateTime;
            DateTime now = DateTime.UtcNow;

            return tokenExpDate >= now;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var token = await storageHelper.GetTokenAsync();
            if (!string.IsNullOrEmpty(token))
            {
                var jwtToken = new JwtSecurityToken(jwtEncodedString: token);
                if (IsTokenExpired(jwtToken))
                {
                    await storageHelper.Logout();
                    return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
                }
                //var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(jwtToken.Claims));
                var claimsIdentity = new ClaimsIdentity(jwtToken.Claims, "user");
                return new AuthenticationState(new ClaimsPrincipal(claimsIdentity));
            }
            else
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
        }
    }
}
