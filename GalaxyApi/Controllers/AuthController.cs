using Data.ViewModels.Auth;
using Domain.Entities;
using Galaxy.Client;
using Grains.Abstractions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GalaxyApi.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ClusterClient clusterClient;
        private readonly IPasswordHasher<User> passwordHasher;

        public AuthController(
            ClusterClient clusterClient, 
            IPasswordHasher<User> passwordHasher)
        {
            this.clusterClient = clusterClient;
            this.passwordHasher = passwordHasher;
        }

        [HttpPost("login")]
        public async Task<LoginResponseViewModel> Login([FromBody]LoginViewModel login)
        {
            IAuthGrain authGrain = clusterClient.Client.GetGrain<IAuthGrain>(login.Username);
            return await authGrain.Login(login);
        }

        [HttpPost("Register")]
        public async Task<LoginResponseViewModel> Register([FromBody]RegisterViewModel registerViewModel)
        {
            return null;
        }

        [HttpPost("hash")]
        public Task<string> HashPassword([FromBody] string password) =>
            Task.FromResult(passwordHasher.HashPassword(new User(), password));
    }
}
