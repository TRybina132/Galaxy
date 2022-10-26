using Domain.Entities;
using Domain.Options;
using Infrastructure.Repository.Abstractions.Queries;
using Infrastructure.Repository.Core;
using Microsoft.Extensions.Options;

namespace Infrastructure.Repository.Implementations.Queries
{
    internal class PlanetQuery : BaseQuery<Planet>, IPlanetQuery
    {
        public PlanetQuery(IOptions<AzureTableOptions> options) : base(options) { }
    }
}
