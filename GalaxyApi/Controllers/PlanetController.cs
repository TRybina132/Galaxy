using AutoMapper;
using Data.ViewModels.Planet;
using Domain.Entities;
using Galaxy.Client;
using Grains.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace GalaxyApi.Controllers
{
    [Route("api/planets")]
    [ApiController]
    public class PlanetController : ControllerBase
    {
        private readonly ClusterClient clusterClient;
        private readonly IMapper mapper;
        private readonly IPlanetGrain planetGrain;

        public PlanetController(ClusterClient clusterClient, IMapper mapper)
        {
            this.mapper = mapper;
            this.clusterClient = clusterClient;
            planetGrain = clusterClient.Client.GetGrain<IPlanetGrain>("instance");
        }

        [HttpGet]
        public async Task<List<PlanetViewModel>> GetAllPlanets()
        {
            var planets = await planetGrain.GetAllPlanets();
            return mapper.Map<List<PlanetViewModel>>(planets);
        }

        [HttpGet("hi")]
        public async Task SayHello() =>
            await planetGrain.SayHello();

        [HttpPost]
        public async Task AddPlanet([FromBody] PlanetCreateViewModel planet)
        {
            var mappedPlanet = mapper.Map<Planet>(planet);
            await planetGrain.InsertPlanet(mappedPlanet);
        }

        [HttpPut]
        public async Task UpdatePlanet([FromBody] PlanetViewModel planet) =>
            await planetGrain.UpdatePlanet(mapper.Map<Planet>(planet));
    }
}
