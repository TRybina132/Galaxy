using AutoMapper;
using Data.ViewModels.Planet;
using Data.ViewModels.Species;
using Domain.Entities;
using Galaxy.Client;
using GalaxyApi.Helpers;
using GalaxyApi.Middleware;
using Grains.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GalaxyApi.Controllers
{
    [Route("api/planets")]
    [Authorize]
    [ApiController]
    public class PlanetController : ControllerBase
    {
        private readonly ClusterClient clusterClient;
        private readonly IMapper mapper;

        public PlanetController(ClusterClient clusterClient, IMapper mapper)
        {
            this.mapper = mapper;
            this.clusterClient = clusterClient;
        }

        [HttpGet]
        public async Task<List<PlanetViewModel>> GetAllPlanets()
        {
            var userId = HttpContext.GetUserIdFromJwtToken();
            var planets = await clusterClient.Client.GetGrain<IPlanetGrain>(userId).GetAllPlanets();
            return mapper.Map<List<PlanetViewModel>>(planets);
        }

        [HttpGet("hi")]
        public async Task SayHello() =>
            await clusterClient.Client.GetGrain<IPlanetGrain>("planets").SayHello();

        [HttpPost]
        public async Task AddPlanet([FromBody] PlanetCreateViewModel planet)
        {
            var mappedPlanet = mapper.Map<Planet>(planet);
            var userId = HttpContext.GetUserIdFromJwtToken();
            await clusterClient.Client.GetGrain<IPlanetGrain>(userId).InsertPlanet(mappedPlanet);
        }

        [HttpPost("addSpecies/{planetId}")]
        public async Task AddSpeciesToPlanet([FromRoute] string planetId, [FromBody] SpeciesViewModel species) =>
            await clusterClient.Client.GetGrain<IPlanetGrain>(planetId)
                .AddSpeciesToPlanet(planetId, mapper.Map<Species>(species));
    }
}
