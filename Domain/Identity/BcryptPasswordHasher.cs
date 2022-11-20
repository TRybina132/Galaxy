using Microsoft.AspNetCore.Identity;

namespace Domain.Identity
{
    public class BcryptPasswordHasher<TUser> : IPasswordHasher<TUser>
        where TUser : class
    {
        public string HashPassword(TUser user, string password) =>
            BCrypt.Net.BCrypt.HashPassword(password);

        public PasswordVerificationResult VerifyHashedPassword(TUser user, string hashedPassword, string providedPassword) =>
            BCrypt.Net.BCrypt.Verify(providedPassword, hashedPassword) ?
                PasswordVerificationResult.Success : PasswordVerificationResult.Failed;
    }
}
