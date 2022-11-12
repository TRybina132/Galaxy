namespace GalaxyApp.ApiClients.Base.Abstractions
{
    public interface IHttpClient<T>
    {
        Task<List<T>> GetAllAsync();
        Task<HttpResponseMessage> AddAsync(T entity);
    }
}
