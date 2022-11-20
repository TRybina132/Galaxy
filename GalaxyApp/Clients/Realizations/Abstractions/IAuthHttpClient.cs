using Data.ViewModels.Auth;

namespace GalaxyApp.ApiClients.Realizations.Abstractions
{
    public interface IAuthHttpClient
    {
        Task<LoginResponseViewModel> LoginAsync(LoginViewModel loginViewModel);
        Task<LoginResponseViewModel> RegisterAsync(RegisterViewModel registerViewModel);
    }
}
