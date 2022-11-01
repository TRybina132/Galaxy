using Data.ViewModels.Auth;

namespace Grains.Handlers.Abstractions
{
    public interface IAuthHandler
    {
        Task<LoginResponseViewModel> GenerateToken(LoginViewModel login);
    }
}
