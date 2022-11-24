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

        public SpeciesController(ClusterClient clusterClient, IMapper mapper)
        {
            this.clusterClient = clusterClient;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<List<SpeciesViewModel>> GetAllSpecies()
        {
            var userId = HttpContext.User.Claims.Where(claim => claim.Type == "id").FirstOrDefault();
            return mapper.Map<List<SpeciesViewModel>>(await clusterClient.Client.GetGrain<ISpeciesGrain>(userId.Value).GetAllSpecies());
        }

        [HttpGet("{id}")]
        public async Task<SpeciesViewModel> GetSpeciesById([FromRoute] string id) =>
            mapper.Map<SpeciesViewModel>(await clusterClient.Client.GetGrain<ISpeciesGrain>(id).FindSpeciesById(id));

        [HttpPost]
        public async Task AddSpecies([FromBody] SpeciesCreateViewModel speciesViewModel) =>
            await clusterClient.Client.GetGrain<ISpeciesGrain>(speciesViewModel.RowKey).AddSpecies(mapper.Map<Species>(speciesViewModel));
    }
}
