using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Orleans;

namespace Galaxy.Client
{
    public static class ClientConfiguration
    {
        //  ᓚᘏᗢ Configuration for app that will use client
        public static void AddClusterClient(this IServiceCollection services)
        {
            services.AddSingleton<ClusterClient>();
            services.AddSingleton<IHostedService>(sp => sp.GetService<ClusterClient>());
            services.AddSingleton(sp => sp.GetService<ClusterClient>().Client);
            services.AddSingleton<IGrainFactory>(sp => sp.GetService<ClusterClient>().Client);
        }
    }
}
