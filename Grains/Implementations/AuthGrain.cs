using Data.ViewModels.Auth;
using Domain.Entities;
using Grains.Abstractions;
using Grains.Handlers.Abstractions;
using Infrastructure.Repository.Abstractions.Queries;
using Orleans;
using System.IdentityModel.Tokens.Jwt;

namespace Grains.Implementations
{
    public class AuthGrain : Grain, IAuthGrain
    {
        private readonly IUserQuery userQuery;
        private readonly IAuthHandler authHandler;

        public AuthGrain(
            IUserQuery userQuery,
            IAuthHandler authHandler)
        {
            this.userQuery = userQuery;
            this.authHandler = authHandler;
        }

        private string GenerateToken(User user)
        {
            var credentials = authHandler.GetUserClaims(user);
            var signature = authHandler.GetSigningCredentials();
            var token = authHandler.GenerateTokenOptions(signature, credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<LoginResponseViewModel> Login(LoginViewModel login)
        {
            try
            {
                User user = await userQuery.GetUserByName(login.Username);
                string token = GenerateToken(user);
                return new LoginResponseViewModel
                {
                    IsSuccess = true,
                    Token = token
                };
            }
            catch (Exception ex)
            {
                return new LoginResponseViewModel
                {
                    IsSuccess = false,
                    ErrorMessage = ex.Message
                };
            }
        }
    }
}
