using Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Grains.Handlers.Abstractions
{
    public interface IAuthHandler
    {
        List<Claim> GetUserClaims(User user);
        SigningCredentials GetSigningCredentials();
        JwtSecurityToken GenerateTokenOptions(
            SigningCredentials signingCredentials,
            List<Claim> userClaims);
    }
}
