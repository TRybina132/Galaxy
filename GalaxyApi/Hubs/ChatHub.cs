using Data.SignalR;
using Data.SignalR.HubsAbstractions;
using Data.ViewModels.Auth;
using Microsoft.AspNetCore.SignalR;

namespace GalaxyApi.Hubs;

//  💖 Here we using strongly typed hub. We can use real
//      client methods instead methods` names  🌈
public class ChatHub : Hub<IChatClient>, IChatHub
{
    public async Task SendMessage(string message)
    {
        var id = Context?.User?.Claims.FirstOrDefault(claim => claim.Type == "id");
        var username = Context?.User?.Claims.FirstOrDefault(claim => claim.Type == "username");
        if (id != null && username != null)
        {
            var user = new UserViewModel()
            {
                RowKey = id.Value,
                Username = username.Value
            };
            
            await Clients.All.ReceiveMessage(user, message);   
        }
    }
}