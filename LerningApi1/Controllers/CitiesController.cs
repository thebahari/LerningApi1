using AutoMapper;
using LerningApi1.Entities;
using LerningApi1.Models;
using LerningApi1.Repository;
using Microsoft.AspNetCore.Mvc;

namespace LerningApi1.Controllers
{
    [ApiController]
    [Route("[Controller]/[Action]")]
    public class CitiesController : ControllerBase
    {
        private readonly ICityRepository cityRepository;
        private readonly IMapper mapper;

        public CitiesController(ICityRepository cityRepository,IMapper mapper)
        {
            this.cityRepository = cityRepository;
            this.mapper = mapper?? throw new ArgumentNullException(nameof(mapper));
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CityWithoutPlaceOfCity>>> GetCities()
        {
            var c =await cityRepository.GetCitiesAcync();
            return Ok(mapper.Map<IEnumerable<CityWithoutPlaceOfCity>>(c));
        }
        [HttpGet("{cityId}")]
        public async Task<ActionResult> GetCity(int cityId, bool includePlace=false)
        {
           var city=await cityRepository.GetCityAcync(cityId,includePlace);
            if(city == null)
            {
                return NotFound();
            }
            if(includePlace)
            {
                return Ok(mapper.Map<CityDto>(city));
            }
            return Ok(mapper.Map<CityWithoutPlaceOfCity>(city));
        }
        

    }
}
