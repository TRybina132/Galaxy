using Data.ViewModels.Auth;
using Domain.Entities;
using Grains.Abstractions;
using Grains.Handlers.Abstractions;
using Infrastructure.Repository.Abstractions.Queries;
using Infrastructure.Repository.Abstractions.Repositories;
using Microsoft.AspNetCore.Identity;
using Orleans;
using System.IdentityModel.Tokens.Jwt;

namespace Grains.Implementations
{
    public class AuthGrain : Grain, IAuthGrain
    {
        private readonly IUserQuery userQuery;
        private readonly IUserRepository userRepository;
        private readonly IAuthHandler authHandler;
        private readonly IPasswordHasher<User> passwordHasher;

        public AuthGrain(
            IUserQuery userQuery,
            IUserRepository userRepository,
            IAuthHandler authHandler,
            IPasswordHasher<User> passwordHasher)
        {
            this.userQuery = userQuery;
            this.authHandler = authHandler;
            this.userRepository = userRepository;
            this.passwordHasher = passwordHasher;
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
                if(passwordHasher.VerifyHashedPassword(user, user.Password,login.Password) == PasswordVerificationResult.Success)
                {
                    string token = GenerateToken(user);
                    return new LoginResponseViewModel
                    {
                        IsSuccess = true,
                        Token = token
                    };
                }
                else
                    return new LoginResponseViewModel
                    {
                        IsSuccess = false,
                        ErrorMessage = "Invalid username or password"
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

        public Task<LoginResponseViewModel> Register(RegisterViewModel register)
        {
            return null;
        }
    }
}
