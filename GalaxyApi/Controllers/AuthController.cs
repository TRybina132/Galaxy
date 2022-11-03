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

        public AuthController(ClusterClient clusterClient)
        {
            this.clusterClient = clusterClient;
        }

        [HttpPost]
        public async Task<LoginResponseViewModel> Login(LoginViewModel login)
        {
            IAuthGrain authGrain = clusterClient.Client.GetGrain<IAuthGrain>(login.Username);
            return await authGrain.Login(login);
        }
    }
}
