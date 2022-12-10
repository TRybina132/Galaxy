using GalaxyApp.Helpers.Abstractions;
using Microsoft.JSInterop;
using System.IdentityModel.Tokens.Jwt;

namespace GalaxyApp.Helpers.Implementations
{
    internal class BrowserStorageHelper : IBrowserStorageHelper
    {
        //  ᓚᘏᗢ Remove these magic strings later
        private readonly IJSRuntime jsRuntime;

        public BrowserStorageHelper(IJSRuntime jsRuntime)
        {
            this.jsRuntime = jsRuntime;
        }

        private long GetTokenExp(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(token);
            var tokenExp = jwtSecurityToken.Claims.First(claim => claim.Type.Equals("exp")).Value;
            var ticks = long.Parse(tokenExp);
            return ticks;
        }

        public async Task<bool> IsExpired(string token = null)
        {
            if(string.IsNullOrEmpty(token))
                token = await jsRuntime.InvokeAsync<string>("localStorage.getItem", "user")
                    .ConfigureAwait(false);

            var tokenTicks = GetTokenExp(token);
            var tokenExpDate = DateTimeOffset.FromUnixTimeSeconds(tokenTicks).UtcDateTime;

            var now = DateTime.Now.ToUniversalTime();

            bool isExpired = tokenExpDate >= now;
            if (isExpired)
                await Logout();
            return isExpired;
        }

        public async Task SetTokenToStorage(string token) =>
            await jsRuntime.InvokeVoidAsync("localStorage.setItem", "user", token)
                .ConfigureAwait(false);

        public async Task<bool> IsAuthenticated()
        {
            string token = await GetTokenAsync();
            return !string.IsNullOrEmpty(token) && !await IsExpired(token);
        }

        public async Task Logout() =>
            await jsRuntime.InvokeVoidAsync("localStorage.removeItem", "user");

        public async Task<string> GetTokenAsync() =>
            await jsRuntime.InvokeAsync<string>("localStorage.getItem", "user");
    }
}
