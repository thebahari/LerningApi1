using AutoMapper;
using LerningApi1.Entities;
using LerningApi1.Models;

namespace LerningApi1.Profiles
{
    public class PlaceOfCityProfile:Profile
    {
        public PlaceOfCityProfile()
        {
            CreateMap<Entities.PlaceOfCity,Models.PlacesToVisitDto>();
            CreateMap<PlaceViewModel,PlaceOfCity>();
            CreateMap<PlaceUpdateViewModel, PlaceOfCity>();
            CreateMap<PlaceOfCity,PlaceUpdateViewModel>();
        }
    }
}
