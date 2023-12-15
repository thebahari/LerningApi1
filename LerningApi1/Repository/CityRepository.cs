using LerningApi1.DbContex;
using LerningApi1.Entities;
using Microsoft.EntityFrameworkCore;

namespace LerningApi1.Repository
{
    public class CityRepository : ICityRepository
    {
        private readonly DbApiLerning db;

        public CityRepository(DbApiLerning db)
        {
            this.db = db;
        }
        public async Task<IEnumerable<Cities>> GetCitiesAcync()
        {
            return await db.Cities.OrderBy(x=>x.Name).ToListAsync();
        }

        public async Task<Cities?> GetCityAcync(int cityId, bool includePlace)
        {
            
            if (includePlace)
            {
                return await db.Cities.Include(c=>c.placeOfCities).Where(x => x.Id == cityId).FirstOrDefaultAsync();

            }
            return await db.Cities.Where(x => x.Id == cityId).FirstOrDefaultAsync();
        }

        public async Task<PlaceOfCity?> GetPlaceOfCityAcync(int cityId, int placeId)
        {
            return await db.PlaceOfCity.
                Where(x=>x.CityId==cityId&&x.Id==placeId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<PlaceOfCity?>> GetPlacesOfCityAcync(int cityId)
        {
            return await db.PlaceOfCity.Where(x=>x.CityId==cityId).ToListAsync();
        }

        public Task<bool> CityExisitsAcync(int cityId)
        {
            return db.Cities.AnyAsync(c=>c.Id==cityId);
        }

        public async Task InsertPlaceOfCity(int cityId, PlaceOfCity place)
        {
            var city = await GetCityAcync(cityId, false);
            if (city != null)
            {
                city.placeOfCities.Add(place);
            }
        }

        public async Task<bool> SaveChengesAcync()
        {
            return (await db .SaveChangesAsync()>0);
        }
    }
}
