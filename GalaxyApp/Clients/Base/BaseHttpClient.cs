using GalaxyApp.ApiClients.Base.Abstractions;
using GalaxyApp.Helpers.Abstractions;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace GalaxyApp.ApiClients.Base
{
    internal abstract class BaseHttpClient<T> : IHttpClient<T>
    {
        protected readonly string token;
        protected readonly HttpClient httpClient;
        protected readonly IBrowserStorageHelper storageHelper;
        protected string Path { get; init; }

        protected BaseHttpClient(IBrowserStorageHelper browserStorageHelper, string path)
        {
            httpClient = new HttpClient();
            Path = path;
            storageHelper = browserStorageHelper;
        }

        public async Task<List<T>> GetAllAsync()
        {
            var token = await storageHelper.GetTokenAsync();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            Console.WriteLine(token);
            var result = await httpClient.GetAsync(Path);
            return await result.Content.ReadFromJsonAsync<List<T>>() ?? throw new Exception();
        }

        public async Task<HttpResponseMessage> AddAsync(T entity)
        {
            var token = await storageHelper.GetTokenAsync();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            return await httpClient.PostAsJsonAsync(Path, entity);
        }
    }
}
