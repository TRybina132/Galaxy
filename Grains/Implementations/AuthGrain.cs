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
        private readonly ISpeciesRepository speciesRepository;

        public AuthGrain(
            IUserQuery userQuery,
            IUserRepository userRepository,
            IAuthHandler authHandler,
            IPasswordHasher<User> passwordHasher,
            ISpeciesRepository speciesRepository)
        {
            this.speciesRepository = speciesRepository;
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

        public async Task<LoginResponseViewModel> Register(RegisterViewModel register)
        {
            User user = new User
            {
                RowKey = Guid.NewGuid().ToString(),
                Email = register.Email,
                Name = register.Name,
                PartitionKey = "User",
                SpeciesType = register.SelectedSpecies
            };

            user.Password = passwordHasher.HashPassword(user, register.Password);
            await userRepository.InsertAsync(user);

            if(string.IsNullOrEmpty(register.SelectedSpecies))
                await speciesRepository.IncrementPopulation(register.SelectedSpecies);

            return await Login(new LoginViewModel
            {
                Username = register.Name,
                Password = register.Password
            });
        }
    }
}
