namespace Domain.Options
{
    public class JwtOptions
    {
        public string SecretKey { get; set; }
        public string ValidIssuer { get; set; }
        public string ValidAudience { get; set; }
        public int LifetimeInMinutes { get; set; }
    }
}
