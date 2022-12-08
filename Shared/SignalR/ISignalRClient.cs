namespace Data.SignalR;

public interface ISignalRClient : IAsyncDisposable
{
    Task InitAsync();
}