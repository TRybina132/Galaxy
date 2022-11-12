namespace GalaxyApp.Helpers.Abstractions
{
    public interface IBrowserStorageHelper
    {
        Task SetTokenToStorage(string token);
        Task<string> GetTokenAsync();
        Task<bool> IsAuthenticated();
        Task Logout();
    }
}
