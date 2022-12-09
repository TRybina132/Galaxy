using Data.SignalR;
using Data.SignalR.HubsAbstractions;
using Data.ViewModels.Auth;
using Microsoft.AspNetCore.SignalR;

namespace GalaxyApi.Hubs;

//  💖 Here we using strongly typed hub. We can use real
//      client methods instead methods` names  🌈
public class ChatHub : Hub, IChatHub
{
    public async Task SendMessage(string message)
    {
        
        await Clients.All.SendAsync("ReceiveMessage",new UserViewModel(), "HELLO");
    }

    public async Task SayHi() =>
        await Clients.All.SendAsync("SayHello");
}