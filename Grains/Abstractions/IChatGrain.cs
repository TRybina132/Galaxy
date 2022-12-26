using Orleans;

namespace Grains.Abstractions;

public interface IChatGrain : IGrainWithStringKey
{
    Task SendMessage();
}