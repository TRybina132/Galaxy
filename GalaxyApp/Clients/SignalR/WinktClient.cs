using Data.SignalR;
using Microsoft.AspNetCore.SignalR.Client;

namespace GalaxyApp.Clients.SignalR
{
    public class WinktClient : IWinktClient
    {
        private const string ApiUrl = "https://dev-api.winkt.me/winktHub";

        private readonly HubConnection connection;

        public async ValueTask DisposeAsync()
        {
            await connection.DisposeAsync();
        }

        public WinktClient()
        {
            connection = new HubConnectionBuilder()
                .WithUrl(ApiUrl)
                .Build();
        }

        public async Task InitAsync()
        {
            try
            {
                await connection.StartAsync();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void SubscribeOnDoSome1(Action<object> action)
        {
            connection.On<object>("DoSome1", action);
        }
    }
}
