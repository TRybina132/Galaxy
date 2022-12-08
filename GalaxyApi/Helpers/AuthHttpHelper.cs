namespace GalaxyApi.Helpers;
    
public static class AuthHttpHelper
{
    public static string GetUserIdFromJwtToken(this HttpContext context)
    {
        var id = context.User.Claims.FirstOrDefault(claim => claim.Type == "id");
        return id?.Value ?? throw new Exception("Not authorized!");
    }
}