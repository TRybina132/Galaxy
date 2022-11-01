using Data.ViewModels.Auth;
using Domain.Entities;
using Grains.Abstractions;
using Grains.Handlers.Abstractions;
using Infrastructure.Repository.Abstractions.Queries;
using Orleans;

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

        public async Task<LoginResponseViewModel> Login(LoginViewModel login)
        {
            //  ᓚᘏᗢ Move to service
            User? user;
            try
            {
                user = await userQuery.GetUserByName(login.Username);
            }
            catch(Exception ex)
            {
                return new LoginResponseViewModel
                {
                    IsSuccess = false,
                    ErrorMessage = ex.Message
                };
            }

            return new LoginResponseViewModel { IsSuccess = true };
        }
    }
}
