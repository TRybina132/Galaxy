using ApiClients.Base.Abstractions;
using Data.ViewModels;

namespace ApiClients.Realizations.Abstractions
{
    public interface IPlanetHttpClient : IHttpClient<PlanetViewModel>
    {
    }
}
