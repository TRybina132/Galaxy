using AutoMapper;
using Domain.Entities;
using Galaxy.Client;
using GalaxyApi.ViewModels;
using Grains.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace GalaxyApi.Controllers
{
    [Route("api/species")]
    [ApiController]
    public class SpeciesController : ControllerBase
    {
        private readonly ClusterClient clusterClient;
        private readonly IMapper mapper;
        private readonly ISpeciesGrain speciesGrain;

        public SpeciesController(ClusterClient clusterClient, IMapper mapper)
        {
            this.clusterClient = clusterClient;
            this.mapper = mapper;
            speciesGrain = clusterClient.Client.GetGrain<ISpeciesGrain>("instance");
        }

        [HttpGet]
        public async Task GetAllSpecies() =>
            mapper.Map<List<SpeciesViewModel>>(await speciesGrain.GetAllSpecies());

        [HttpPost]
        public async Task AddSpecies([FromBody] SpeciesCreateViewModel speciesViewModel) =>
            await speciesGrain.AddSpecies(mapper.Map<Species>(speciesViewModel));
    }
}
