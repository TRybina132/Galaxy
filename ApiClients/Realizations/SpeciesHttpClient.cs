using ApiClients.Base;
using ApiClients.Configuration;
using ApiClients.Realizations.Abstractions;
using GalaxyApi.ViewModels;

namespace ApiClients.Realizations
{
    internal class SpeciesHttpClient : BaseHttpClient<SpeciesViewModel>, ISpeciesHttpClient
    {
        public SpeciesHttpClient() : base($"{ClientConstants.ApiUrl}/species") { }
    }
}
