using ApiClients.Configuration;
using ApiClients.Realizations.Abstractions;
using Data.ViewModels.Auth;
using System.Net.Http.Json;

namespace ApiClients.Realizations
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
                await httpClient.PostAsJsonAsync("https://localhost:5152/api/auth/login", loginViewModel);
            return await response.Content.ReadFromJsonAsync<LoginResponseViewModel>() ?? 
                    new LoginResponseViewModel
                    {
                        ErrorMessage = $"Status code: {response.StatusCode}",
                        IsSuccess = true
                    };
        }
    }
}
