using AutoMapper;
using Data.ViewModels;
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
