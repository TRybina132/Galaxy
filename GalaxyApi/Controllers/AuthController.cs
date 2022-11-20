using Data.ViewModels.Auth;
using Galaxy.Client;
using Grains.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace GalaxyApi.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ClusterClient clusterClient;

        public AuthController(
            ClusterClient clusterClient)
        {
            this.clusterClient = clusterClient;
        }

        [HttpPost("login")]
        public async Task<LoginResponseViewModel> Login([FromBody]LoginViewModel login)
        {
            IAuthGrain authGrain = clusterClient.Client.GetGrain<IAuthGrain>(login.Username);
            return await authGrain.Login(login);
        }

        [HttpPost("register")]
        public async Task<LoginResponseViewModel> Register([FromBody] RegisterViewModel registerViewModel) =>
            await clusterClient.Client.GetGrain<IAuthGrain>(registerViewModel.Username).Register(registerViewModel);
    }
}