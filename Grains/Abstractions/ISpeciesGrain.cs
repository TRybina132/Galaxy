using Domain.Entities;
using Orleans;

namespace Grains.Abstractions
{
    public interface ISpeciesGrain : IGrainWithStringKey
    {
        Task<List<Species>> GetAllSpecies();
        Task AddSpecies(Species species);
    }
}
