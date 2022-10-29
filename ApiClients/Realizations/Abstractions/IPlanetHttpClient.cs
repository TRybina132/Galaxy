using ApiClients.Base.Abstractions;
using GalaxyApi.ViewModels.Planet;

namespace ApiClients.Realizations.Abstractions
{
    public interface IPlanetHttpClient : IHttpClient<PlanetViewModel>
    {
    }
}
