using ApiClients.Base.Abstractions;
using System.Net.Http.Json;

namespace ApiClients.Base
{
    internal abstract class BaseHttpClient<T> : IHttpClient<T>
    {
        protected readonly string path;
        protected readonly HttpClient httpClient;

        protected BaseHttpClient(string path)
        {
            this.path = path;
            httpClient = new HttpClient();
        }

        public async Task<List<T>> GetAllAsync()
        {
            var result = await httpClient.GetAsync(path);
            return await result.Content.ReadFromJsonAsync<List<T>>() ?? throw new Exception();
        }

        public async Task<HttpResponseMessage> AddAsync(T entity) =>
            await httpClient.PostAsJsonAsync(path, entity);
    }
}
