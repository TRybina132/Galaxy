using GalaxyApp.ApiClients.Base.Abstractions;
using Data.ViewModels.Planet;

namespace GalaxyApp.ApiClients.Realizations.Abstractions
{
    public interface IPlanetHttpClient : IHttpClient<PlanetViewModel>
    {
        public Task<HttpResponseMessage> AddPlanetAsync(PlanetCreateViewModel planet);
    }
}
