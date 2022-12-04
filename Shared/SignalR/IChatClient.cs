using Data.ViewModels.Auth;

namespace Data.SignalR;

public interface IChatClient
{
    Task ReceiveMessage(UserViewModel user, string message);
}