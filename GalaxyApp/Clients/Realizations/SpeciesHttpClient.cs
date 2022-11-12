using GalaxyApp.ApiClients.Base;
using GalaxyApp.ApiClients.Configuration;
using GalaxyApp.ApiClients.Realizations.Abstractions;
using Data.ViewModels.Species;
using GalaxyApp.Helpers.Abstractions;

namespace GalaxyApp.ApiClients.Realizations
{
    internal class SpeciesHttpClient : BaseHttpClient<SpeciesViewModel>, ISpeciesHttpClient
    {
        public SpeciesHttpClient(IBrowserStorageHelper browserStorageHelper) : base(browserStorageHelper, $"{ClientConstants.ApiUrl}/species") { }
    }
}
