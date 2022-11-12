using GalaxyApp.ApiClients.Base;
using GalaxyApp.ApiClients.Configuration;
using GalaxyApp.ApiClients.Realizations.Abstractions;
using Data.ViewModels.Planet;
using System.Net.Http.Json;

namespace GalaxyApp.ApiClients.Realizations
{
    internal class PlanetHttpClient : BaseHttpClient<PlanetViewModel>, IPlanetHttpClient
    {
        public PlanetHttpClient()
            : base($"{ClientConstants.ApiUrl}/planets") { }

        public async Task<HttpResponseMessage> AddPlanetAsync(PlanetCreateViewModel planet)
        {
            planet.RowKey = Guid.NewGuid().ToString();
            return await httpClient.PostAsJsonAsync(path, planet);
        }
    }
}
