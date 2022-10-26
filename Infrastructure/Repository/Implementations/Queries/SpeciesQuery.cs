using Domain.Entities;
using Domain.Options;
using Infrastructure.Repository.Abstractions.Queries;
using Infrastructure.Repository.Core;
using Microsoft.Extensions.Options;

namespace Infrastructure.Repository.Implementations.Queries
{
    internal class SpeciesQuery : BaseQuery<Species>, ISpeciesQuery
    {
        public SpeciesQuery(IOptions<AzureTableOptions> options) : base(options) { }
    }
}
