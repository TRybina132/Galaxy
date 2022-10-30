using ApiClients.Base.Abstractions;
using Data.ViewModels.Planet;

namespace ApiClients.Realizations.Abstractions
{
    public interface IPlanetHttpClient : IHttpClient<PlanetViewModel>
    {
        public Task<HttpResponseMessage> AddPlanetAsync(PlanetCreateViewModel planet);
    }
}
