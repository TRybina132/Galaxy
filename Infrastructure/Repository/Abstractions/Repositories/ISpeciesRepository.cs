using Domain.Entities;
using Infrastructure.Repository.Core.Abstractions;

namespace Infrastructure.Repository.Abstractions.Repositories
{
    public interface ISpeciesRepository : IBaseRepository<Species>
    {
        Task IncrementPopulation(string speciesName);
    }
}
