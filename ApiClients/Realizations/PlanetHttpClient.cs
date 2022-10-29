using ApiClients.Base;
using ApiClients.Realizations.Abstractions;
using GalaxyApi.ViewModels.Planet;

namespace ApiClients.Realizations
{
    internal class PlanetHttpClient : BaseHttpClient<PlanetViewModel>, IPlanetHttpClient
    {
        public PlanetHttpClient(string path) : base(path)
        {
        }
    }
}
