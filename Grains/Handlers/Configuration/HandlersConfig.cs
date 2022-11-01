using Grains.Handlers.Abstractions;
using Grains.Handlers.Realizations;
using Microsoft.Extensions.DependencyInjection;

namespace Grains.Handlers.Configuration
{
    public static class HandlersConfig
    {
        public static void AddHandlers(this IServiceCollection services)
        {
            services.AddScoped<IAuthHandler, AuthHandler>();
        }
    }
}
