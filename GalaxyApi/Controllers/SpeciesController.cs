using AutoMapper;
using Data.ViewModels.Species;
using Domain.Entities;
using Galaxy.Client;
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
        private readonly ISpeciesGrain speciesGrain;

        public SpeciesController(ClusterClient clusterClient, IMapper mapper)
        {
            this.clusterClient = clusterClient;
            this.mapper = mapper;
            speciesGrain = clusterClient.Client.GetGrain<ISpeciesGrain>("instance");
        }

        [HttpGet]
        public async Task<List<SpeciesViewModel>> GetAllSpecies() =>
            mapper.Map<List<SpeciesViewModel>>(await speciesGrain.GetAllSpecies());

        [HttpGet("{id}")]
        public async Task<SpeciesViewModel> GetSpeciesById([FromRoute] string id) =>
            mapper.Map<SpeciesViewModel>(await speciesGrain.FindSpeciesById(id));

        [HttpPost]
        public async Task AddSpecies([FromBody] SpeciesCreateViewModel speciesViewModel) =>
            await speciesGrain.AddSpecies(mapper.Map<Species>(speciesViewModel));
    }
}
