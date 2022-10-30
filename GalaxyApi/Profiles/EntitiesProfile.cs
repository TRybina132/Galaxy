using AutoMapper;
using Data.ViewModels.Planet;
using Domain.Entities;

namespace GalaxyApi.Profiles
{
    public class EntitiesProfile : Profile
    {
        public EntitiesProfile()
        {
            CreateMap<Planet, PlanetViewModel>().ReverseMap();
            CreateMap<PlanetCreateViewModel, Planet>();
        }
    }
}
