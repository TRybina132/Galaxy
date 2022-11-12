using GalaxyApp.Helpers.Abstractions;
using GalaxyApp.Helpers.Implementations;

namespace GalaxyApp.Helpers.Configurations
{
    public static class HelpersConfiguration
    {
        public static void AddHelpers(this IServiceCollection services)
        {
            services.AddScoped<IBrowserStorageHelper, BrowserStorageHelper>();
        }
    }
}
