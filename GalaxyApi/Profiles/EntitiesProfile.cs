using AutoMapper;
using Data.ViewModels.Planet;
using Domain.Entities;
using GalaxyApi.ViewModels;
using GalaxyApi.ViewModels.Planet;

namespace GalaxyApi.Profiles
{
    public class EntitiesProfile : Profile
    {
        public EntitiesProfile()
        {
            CreateMap<Planet, PlanetViewModel>().ReverseMap();
            CreateMap<PlanetCreateViewModel, Planet>();
            CreateMap<SpeciesCreateViewModel, Species>();
            CreateMap<Species, SpeciesViewModel>().ReverseMap();
        }
    }
}
