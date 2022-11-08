using Domain.Entities;
using Galaxy.Client;
using GalaxyApi.Middleware;
using GalaxyApi.Profiles;
using Infrastructure.Configuration;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;

namespace GalaxyApi.Configurations
{
    public static class ServicesConfig
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<ExceptionHandlerMiddleware>();
            services.AddRepositories();
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddClusterClient();
            services.AddAutoMapper(typeof(EntitiesProfile).Assembly);

            //services.AddIdentity<User, IdentityRole<string>>();

            services.AddCors(ConfigureCors);

            services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter a valid token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type=ReferenceType.SecurityScheme,
                                Id="Bearer"
                            }
                        },
                        new string[]{}
                    }
                });
            });
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
