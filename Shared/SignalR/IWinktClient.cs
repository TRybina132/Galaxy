namespace Data.SignalR
{
    public interface IWinktClient : ISignalRClient
    {
        void SubscribeOnDoSome1(Action<object> action);
    }
}
