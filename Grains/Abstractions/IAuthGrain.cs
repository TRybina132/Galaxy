using Data.ViewModels.Auth;
using Orleans;

namespace Grains.Abstractions
{
    public interface IAuthGrain : IGrainWithStringKey
    {
        Task<LoginResponseViewModel> Login(LoginViewModel login);
    }
}
