using Data.ViewModels.Auth;
using Grains.Abstractions;
using Orleans;

namespace Grains.Implementations
{
    public class AuthGrain : Grain, IAuthGrain
    {
        public Task<LoginResponseViewModel> Login(LoginViewModel login)
        {
            return null;
        }
    }
}
