using Data.ViewModels.Auth;

namespace Data.SignalR;

public interface IChatClient : ISignalRClient
{
    Task ReceiveMessage(UserViewModel user, string message);
    Task SendMessage(string message);
    Task SayHello();
    Action OnSayHello { get; set; }
    Action<UserViewModel, string> OnMessageReceived { get; set; }
}