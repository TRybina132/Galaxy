using Data.ViewModels.Auth;
using Domain.Entities;
using Grains.Handlers.Abstractions;
using Infrastructure.Repository.Abstractions.Queries;

namespace Grains.Handlers.Realizations
{
    public class AuthHandler : IAuthHandler
    {
        private readonly IUserQuery userQuery;

        public AuthHandler(IUserQuery userQuery)
        {
            this.userQuery = userQuery;
        }

        public async Task<LoginResponseViewModel> GenerateToken(LoginViewModel login)
        {
            try
            {
                User user = await userQuery.GetUserByName(login.Username);
                
            }
            catch (Exception ex)
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
