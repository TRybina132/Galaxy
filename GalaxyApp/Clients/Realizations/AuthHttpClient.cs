using GalaxyApp.ApiClients.Configuration;
using GalaxyApp.ApiClients.Realizations.Abstractions;
using Data.ViewModels.Auth;
using System.Net.Http.Json;

namespace GalaxyApp.ApiClients.Realizations
{
    internal class AuthHttpClient : IAuthHttpClient
    {
        private const string path = $"{ClientConstants.ApiUrl}/auth";
        private readonly HttpClient httpClient;

        public AuthHttpClient()
        {
            httpClient = new HttpClient();
        }

        public async Task<LoginResponseViewModel> LoginAsync(LoginViewModel loginViewModel)
        {
            var response =
                await httpClient.PostAsJsonAsync(path + "/login", loginViewModel);
            return await response.Content.ReadFromJsonAsync<LoginResponseViewModel>() ?? 
                    new LoginResponseViewModel
                    {
                        ErrorMessage = $"Status code: {response.StatusCode}",
                        IsSuccess = false
                    };
        }

        public async Task<LoginResponseViewModel> RegisterAsync(RegisterViewModel registerViewModel)
        {
            var response = 
                await httpClient.PostAsJsonAsync(path + "/register", registerViewModel);

            return await response.Content.ReadFromJsonAsync<LoginResponseViewModel>() ??
                new LoginResponseViewModel
                {
                    ErrorMessage = $"Status code: {response.StatusCode}",
                    IsSuccess = false
                };
        }
    }
}
