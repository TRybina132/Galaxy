using GalaxyApp.Helpers.Abstractions;
using Microsoft.JSInterop;

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

        public async Task SetTokenToStorage(string token) =>
            await jsRuntime.InvokeVoidAsync("localStorage.setItem", "user", token)
                .ConfigureAwait(false);

        public async Task<bool> IsAuthenticated() =>
            await jsRuntime.InvokeAsync<string>("localStorage.getItem", "user") != null;

        public async Task Logout() =>
            await jsRuntime.InvokeVoidAsync("localStorage.removeItem", "user");

        public async Task<string> GetTokenAsync() =>
            await jsRuntime.InvokeAsync<string>("localStorage.getItem", "user");
    }
}
