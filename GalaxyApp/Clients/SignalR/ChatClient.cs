using Data.SignalR;
using Data.ViewModels.Auth;
using Microsoft.AspNetCore.SignalR.Client;

namespace GalaxyApp.Clients.SignalR;

public class ChatClient : IChatClient
{
    private const string ApiUrl = "https://localhost:5152/Chat";
    
    private readonly HubConnection connection;
    
    public Action<UserViewModel, string> OnMessageReceived { get; set; }
    public Action OnSayHello { get; set; }

    public ChatClient()
    {
        connection = new HubConnectionBuilder()
            .WithUrl(ApiUrl)
            .Build();
    }

    public Task ReceiveMessage(UserViewModel user, string message)
    {
        OnMessageReceived(user, message);
        return Task.CompletedTask;
    }

    public async Task SendMessage(string message)
    {
        await connection.InvokeAsync(message);
    }

    public Task SayHello()
    {
        OnSayHello();
        return Task.CompletedTask;
    }

    public async Task InitAsync()
    {
        try
        {
            await connection.StartAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    
    public async ValueTask DisposeAsync() =>
        await connection.DisposeAsync();
}