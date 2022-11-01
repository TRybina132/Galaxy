using Domain.Entities;
using Domain.Options;
using Grains.Handlers.Abstractions;
using Infrastructure.Repository.Abstractions.Queries;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Grains.Handlers.Realizations
{
    public class AuthHandler : IAuthHandler
    {
        private readonly IUserQuery userQuery;
        private readonly JwtOptions jwtOptions;

        public AuthHandler(
            IUserQuery userQuery,
            IOptions<JwtOptions> jwtOptions)
        {
            this.userQuery = userQuery;
            this.jwtOptions = jwtOptions.Value;
        }

        public List<Claim> GetUserClaims(User user) =>
            new List<Claim>
            {
                new Claim("username", user.Name),
                new Claim("id", user.RowKey)
            };

        public JwtSecurityToken GenerateTokenOptions(
            SigningCredentials signingCredentials,
            List<Claim> userClaims)
        {
            var lifetime = DateTime.Now.AddMinutes(Convert.ToDouble(jwtOptions.LifetimeInMinutes));

            var token = new JwtSecurityToken(
                issuer: jwtOptions.ValidIssuer,
                audience: jwtOptions.ValidAudience,
                claims: userClaims,
                expires: lifetime,
                signingCredentials: signingCredentials);

            return token;
        }

        public SigningCredentials GetSigningCredentials()
        {
            var key = Encoding.UTF8.GetBytes(jwtOptions.SecretKey);
            var secret = new SymmetricSecurityKey(key);
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }
    }
}
