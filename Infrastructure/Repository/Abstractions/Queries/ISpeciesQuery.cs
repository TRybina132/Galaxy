using Domain.Entities;
using Infrastructure.Repository.Core.Abstractions;

namespace Infrastructure.Repository.Abstractions.Queries
{
    public interface ISpeciesQuery : IBaseQuery<Species>
    {
        Task<Species> GetSpeciesByName(string name);
    }
}
