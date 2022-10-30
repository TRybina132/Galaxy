using Galaxy.Client;
using GalaxyApi.Profiles;
using Microsoft.AspNetCore.Cors.Infrastructure;

namespace GalaxyApi.Configurations
{
    public static class ServicesConfig
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddClusterClient();
            services.AddAutoMapper(typeof(EntitiesProfile).Assembly);

            services.AddCors(ConfigureCors);
        }

        private static void ConfigureCors(CorsOptions corsOptions)
        {
            corsOptions.AddPolicy("blazor",
                policy =>
                {
                    policy.WithOrigins("https://localhost:44398");
                    policy.WithHeaders("*");
                    policy.WithMethods("*");
                });
        }
    }
}
