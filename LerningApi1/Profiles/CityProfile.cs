using AutoMapper;
using LerningApi1.Entities;
using LerningApi1.Models;

namespace LerningApi1.Profiles
{
    public class CityProfile:Profile
    {
        public CityProfile()
        {
            CreateMap<Cities, CityWithoutPlaceOfCity>();
            CreateMap<Cities,CityDto>();
        }
    }
}
