using Data.ViewModels.Auth;

namespace ApiClients.Realizations.Abstractions
{
    public interface IAuthHttpClient
    {
        Task<LoginResponseViewModel> LoginAsync(LoginViewModel loginViewModel);
    }
}
