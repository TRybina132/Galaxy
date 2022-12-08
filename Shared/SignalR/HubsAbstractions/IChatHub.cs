using Data.ViewModels.Auth;

namespace Data.SignalR.HubsAbstractions;

public interface IChatHub
{
    Task SendMessage(string message);
    Task SayHi();
}