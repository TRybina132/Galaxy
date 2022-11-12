using GalaxyApp.Helpers.Abstractions;
using Microsoft.AspNetCore.Components.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace GalaxyApp.Security
{
    public class CustomAuthenticayionProvider : AuthenticationStateProvider
    {
        private readonly IBrowserStorageHelper storageHelper;

        public CustomAuthenticayionProvider(IBrowserStorageHelper storageHelper)
        {
            this.storageHelper = storageHelper;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var token = await storageHelper.GetTokenAsync();
            if (!string.IsNullOrEmpty(token))
            {
                var jwtToken = new JwtSecurityToken(jwtEncodedString: token);
                //var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(jwtToken.Claims));
                var claimsIdentity = new ClaimsIdentity(jwtToken.Claims, "user");
                return new AuthenticationState(new ClaimsPrincipal(claimsIdentity));
            }
            else
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
        }
    }
}
