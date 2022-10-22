﻿using Domain.Entities;
using Orleans;

namespace Grains.Abstractions
{
    public interface IPlanetGrain : IGrainWithStringKey
    {
        Task SayHello();
        Task<List<Planet>> GetAllPlanets();
        Task InsertPlanet(Planet planet);
    }
}
