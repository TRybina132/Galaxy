using ApiClients.Base;
using ApiClients.Configuration;
using ApiClients.Realizations.Abstractions;
using Data.ViewModels;

namespace ApiClients.Realizations
{
    internal class PlanetHttpClient : BaseHttpClient<PlanetViewModel>, IPlanetHttpClient
    {
        public PlanetHttpClient() : base($"{ClientConstants.ApiUrl}/planets")
        {
        }
    }
}
