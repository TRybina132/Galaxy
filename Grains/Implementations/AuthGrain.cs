using Data.ViewModels.Auth;
using Domain.Entities;
using Grains.Abstractions;
using Infrastructure.Repository.Abstractions.Queries;
using Orleans;

namespace Grains.Implementations
{
    public class AuthGrain : Grain, IAuthGrain
    {
        private readonly IUserQuery userQuery;

        public AuthGrain(IUserQuery userQuery)
        {
            this.userQuery = userQuery;
        }

        public async Task<LoginResponseViewModel> Login(LoginViewModel login)
        {
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
