using Domain.Entities;
using Domain.Options;
using Infrastructure.Repository.Core;
using Infrastructure.Repository.Core.Abstractions;
using Microsoft.Extensions.Options;

namespace Infrastructure.Repository.Implementations
{
    internal class PlanetQuery : BaseQuery<Planet>, IPlanetQuery
    {
        public PlanetQuery(IOptions<AzureTableOptions> options) : base(options) { }
    }
}
