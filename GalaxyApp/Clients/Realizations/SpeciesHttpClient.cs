using GalaxyApp.ApiClients.Base;
using GalaxyApp.ApiClients.Configuration;
using GalaxyApp.ApiClients.Realizations.Abstractions;
using Data.ViewModels.Species;

namespace GalaxyApp.ApiClients.Realizations
{
    internal class SpeciesHttpClient : BaseHttpClient<SpeciesViewModel>, ISpeciesHttpClient
    {
        public SpeciesHttpClient() : base($"{ClientConstants.ApiUrl}/species") { }
    }
}
