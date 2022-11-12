using GalaxyApp.ApiClients.Configuration;
using GalaxyApp;
using GalaxyApp.Helpers.Configurations;
using GalaxyApp.Security;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:5152") });
builder.Services.AddMudServices();
builder.Services.AddApiClients();
builder.Services.AddHelpers();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticayionProvider>();

await builder.Build().RunAsync();