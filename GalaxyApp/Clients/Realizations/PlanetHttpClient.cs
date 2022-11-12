using GalaxyApp.ApiClients.Base;
using GalaxyApp.ApiClients.Configuration;
using GalaxyApp.ApiClients.Realizations.Abstractions;
using Data.ViewModels.Planet;
using System.Net.Http.Json;
using GalaxyApp.Helpers.Abstractions;
using System.Net.Http.Headers;

namespace GalaxyApp.ApiClients.Realizations
{
    internal class PlanetHttpClient : BaseHttpClient<PlanetViewModel>, IPlanetHttpClient
    {
        public PlanetHttpClient(IBrowserStorageHelper browserStorageHelper)
            : base(browserStorageHelper,$"{ClientConstants.ApiUrl}/planets") { }

        public async Task<HttpResponseMessage> AddPlanetAsync(PlanetCreateViewModel planet)
        {
            var token = await storageHelper.GetTokenAsync();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            planet.RowKey = Guid.NewGuid().ToString();
            return await httpClient.PostAsJsonAsync(Path, planet);
        }
    }
}
