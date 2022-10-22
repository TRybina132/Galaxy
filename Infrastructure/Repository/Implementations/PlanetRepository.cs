using Domain.Entities;
using Infrastructure.Repository.Abstractions;
using ManagedCode.Repository.AzureTable;
using System.Diagnostics.CodeAnalysis;

namespace Infrastructure.Repository.Implementations
{
    internal class PlanetRepository : AzureTableRepository<Planet>, IPlanetRepository
    {
        public PlanetRepository([NotNull] AzureTableRepositoryOptions options) : base(options)
        {

        }
    }
}
