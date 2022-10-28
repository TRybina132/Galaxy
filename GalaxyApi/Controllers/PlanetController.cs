using AutoMapper;
using Domain.Entities;
using Galaxy.Client;
using GalaxyApi.ViewModels;
using GalaxyApi.ViewModels.Planet;
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
        public async Task AddPlanet([FromBody] PlanetCreateViewModel planet) =>
            await planetGrain.InsertPlanet(mapper.Map<Planet>(planet));

        [HttpPost("addSpecies/{planetId}")]
        public async Task AddSpeciesToPlanet([FromRoute] string planetId, [FromBody] SpeciesViewModel species) =>
            await planetGrain.AddSpeciesToPlanet(planetId, mapper.Map<Species>(species));
    }
}
