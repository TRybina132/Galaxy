using Domain.Entities;
using Domain.Options;
using Infrastructure.Repository.Core;
using Microsoft.Extensions.Options;

namespace Infrastructure.Repository.Implementations
{
    internal class PlanetQuery : BaseQuery<Planet>
    {
        public PlanetQuery(IOptions<AzureTableOptions> options) : base(options) { }
    }
}
