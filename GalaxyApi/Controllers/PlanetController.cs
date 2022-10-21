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

        public PlanetController(ClusterClient clusterClient)
        {
            this.clusterClient = clusterClient;
        }

        [HttpGet("hi")]
        public async Task SayHello()
        {
            var grain = clusterClient.Client.GetGrain<IPlanetGrain>("instance");
            await grain.SayHello();   
        }
    }
}
