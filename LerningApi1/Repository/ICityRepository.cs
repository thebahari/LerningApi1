using LerningApi1.Entities;
using LerningApi1.Models;

namespace LerningApi1.Repository
{
    public interface ICityRepository
    {
        Task<Cities?>GetCityAcync(int cityId, bool includePlace);
        Task<bool> CityExisitsAcync(int cityId);
        Task<IEnumerable<Cities>>GetCitiesAcync();
        Task<IEnumerable<PlaceOfCity?>> GetPlacesOfCityAcync(int cityId);
        Task<PlaceOfCity?> GetPlaceOfCityAcync(int cityId,int placeId);
        Task InsertPlaceOfCity(int cityId,PlaceOfCity place);
        Task<bool> SaveChengesAcync();
    }
}
