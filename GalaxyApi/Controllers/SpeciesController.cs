using AutoMapper;
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
    [Route("api/species")]
    [Authorize]
    [ApiController]
    public class SpeciesController : ControllerBase
    {
        private readonly ClusterClient clusterClient;
        private readonly IMapper mapper;

        public SpeciesController(ClusterClient clusterClient, IMapper mapper)
        {
            this.clusterClient = clusterClient;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<List<SpeciesViewModel>> GetAllSpecies()
        {
            var userId = HttpContext.GetUserIdFromJwtToken();
            return mapper.Map<List<SpeciesViewModel>>(await clusterClient.Client.GetGrain<ISpeciesGrain>(userId).GetAllSpecies());
        }

        [HttpGet("{id}")]
        public async Task<SpeciesViewModel> GetSpeciesById([FromRoute] string id) =>
            mapper.Map<SpeciesViewModel>(await clusterClient.Client.GetGrain<ISpeciesGrain>(id).GetSpecies());

        [HttpGet("byName/{speciesName}")]
        public async Task<SpeciesViewModel> GetSpeciesByName([FromRoute] string speciesName) =>
            mapper.Map<SpeciesViewModel>(await clusterClient.Client.GetGrain<ISpeciesGrain>(speciesName).FindSpeciesByName(speciesName));

        [HttpPost]
        public async Task AddSpecies([FromBody] SpeciesCreateViewModel speciesViewModel) =>
            await clusterClient.Client.GetGrain<ISpeciesGrain>(HttpContext.GetUserIdFromJwtToken()).AddSpecies(mapper.Map<Species>(speciesViewModel));
    }
}
