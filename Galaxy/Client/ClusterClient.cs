using Grains.Abstractions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Orleans;
using Orleans.Configuration;
using Orleans.Hosting;
using Orleans.Runtime;

namespace Galaxy.Client
{
    //  🌈 We implements IHostedService to register this service in Di container,
    //          and it can be started and stopped💖
    public class ClusterClient : IHostedService
    {
        private IClusterClient ConfigureClient(ClusterOptions clusterOptions)
        {
            ClientBuilder clientBuilder = new ClientBuilder();
            clientBuilder.Configure<ClusterOptions>(options =>
            {
                options.ClusterId = clusterOptions.ClusterId;
                options.ServiceId = clusterOptions.ServiceId;
            });

            clientBuilder.UseLocalhostClustering();
            clientBuilder.ConfigureApplicationParts(
                parts => parts.AddApplicationPart(typeof(IPlanetGrain).Assembly));

            clientBuilder.AddSimpleMessageStreamProvider("ActionsProvider");

            return clientBuilder.Build();
        }

        public IClusterClient Client { get; }

        public ClusterClient(IOptions<ClusterOptions> clusterOptions)
        {
            Client = ConfigureClient(clusterOptions.Value);
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            if (Client == null)
                return;

            //  ✨ Retry policy 💫
            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    await Client.Connect();
                    break;
                }
                catch (SiloUnavailableException e)
                {
                    await Task.Delay(TimeSpan.FromSeconds(1), cancellationToken);
                }
            }
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await Client.Close();
            Client.Dispose();
        }
    }
}
