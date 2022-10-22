using AutoMapper;
using Domain.Entities;
using GalaxyApi.ViewModels.Planet;

namespace GalaxyApi.Profiles
{
    public class EntitiesProfile : Profile
    {
        public EntitiesProfile()
        {
            CreateMap<Planet, PlanetViewModel>();
            CreateMap<PlanetCreateViewModel, Planet>();
        }
    }
}
