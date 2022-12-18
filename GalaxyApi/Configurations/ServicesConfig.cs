using Domain.Entities;
using Domain.Identity;
using Galaxy.Client;
using GalaxyApi.Middleware;
using GalaxyApi.Profiles;
using GalaxyApi.Security;
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
            services.AddSignalR();
            
            services.AddScoped<IPasswordHasher<User>, BcryptPasswordHasher<User>>();
            services.AddTransient<IUserStore<User>, UserStore>();


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
                    policy.WithOrigins("http://localhost:44398");
                    policy.WithHeaders("*");
                    policy.WithMethods("*");
                });
        }
    }
}
