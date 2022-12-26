using Grains.Abstractions;
using Orleans;

namespace Grains.Implementations;

public class ChatGrain : Grain, IChatGrain
{
    public Task SendMessage()
    {
        throw new NotImplementedException();
    }
}