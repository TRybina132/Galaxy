﻿using Domain.Options;
using Grains.Implementations;
using Infrastructure.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Orleans;
using Orleans.Configuration;
using Orleans.Hosting;
using System.Reflection;

try
{
    IHost host = await StartSiloAsync(args);
    Console.WriteLine("Press any key to stop silo");
    Console.ReadKey();
    await host.StopAsync();
    host.Dispose();
}
catch(Exception ex)
{
    Console.WriteLine(ex.Message);
    return;
}

return;

static async Task<IHost> StartSiloAsync(string[] args)
{
    //  ᓚᘏᗢ Configuring services just like in asp.net 
    IHostBuilder builder = Host.CreateDefaultBuilder(args);

    builder.ConfigureAppConfiguration(app =>
        app.AddJsonFile("appsettings.json"));

    builder.UseOrleans((context, siloBuilder) =>
    {
        Assembly grainsAssembly = typeof(PlanetGrain).Assembly;

        siloBuilder.UseLocalhostClustering()
            .Configure<ClusterOptions>(context.Configuration.GetSection("ClusterConfig"));

        siloBuilder.Configure<AzureTableOptions>
            (context.Configuration.GetSection("AzureTable"));

        siloBuilder.ConfigureApplicationParts(
            parts => parts.AddApplicationPart(grainsAssembly).WithReferences());

        siloBuilder.ConfigureServices(services =>
        {
            services.AddRepositories();
        });
    });

    IHost host = builder.Build();
    await host.StartAsync();
    return host;
}