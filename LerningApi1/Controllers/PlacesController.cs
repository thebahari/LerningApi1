using AutoMapper;
using CityInfo.API.Services;
using LerningApi1.Entities;
using LerningApi1.Models;
using LerningApi1.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;
using System.Numerics;

namespace LerningApi1.Controllers
{
    [Route("api/[controller]/{cityid}")]
    [ApiController]
    public class PlacesController : ControllerBase
    {
        #region Dependecies
        private readonly ILogger<PlacesController> _logger;
        private readonly IMailService _mailService;
        private readonly ICityRepository cityRepository;
        private readonly IMapper mapper;
        private readonly CitiesDataStore citiesDataStore;

        public PlacesController(ILogger<PlacesController> logger,
            IMailService localMailService, CitiesDataStore citiesDataStore, ICityRepository cityRepository,
            IMapper mapper)
        {
            this.cityRepository = cityRepository;
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _mailService = localMailService ?? throw new ArgumentNullException(nameof(localMailService));
            this.citiesDataStore = citiesDataStore;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        #endregion


        #region GetPlaces
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlacesToVisitDto>>> GetPlaces(int cityid)
        {
            if (!await cityRepository.CityExisitsAcync(cityid))
            {

                _logger.LogError($"city with id {cityid} in not found...");
                return NotFound();
            }
            var places = await cityRepository.GetPlacesOfCityAcync(cityid);
            return Ok(mapper.Map<IEnumerable<PlacesToVisitDto>>(places));
        }
        #endregion

        #region GetPlaceOfCity
        [HttpGet("{placeid}", Name = "GetPlaceOfCity")]
        public async Task<ActionResult> GetPlaceOfCity(int cityid, int placeid)
        {
            if (!await cityRepository.CityExisitsAcync(cityid))
            {
                _logger.LogError($"city with id {cityid} in not found...");
                return NotFound();
            }
            var place = await cityRepository.GetPlaceOfCityAcync(cityid, placeid);
            return Ok(mapper.Map<PlacesToVisitDto>(place));
        }

        #endregion

        #region Insert
        [HttpPost]
        public async Task<ActionResult<PlacesToVisitDto>> InsertPlace(int cityid, PlaceViewModel p)
        {
            if (!await cityRepository.CityExisitsAcync(cityid))
            {
                return NotFound();
            }
            var finalPlace = mapper.Map<PlaceOfCity>(p);
            await cityRepository.InsertPlaceOfCity(cityid, finalPlace);
            await cityRepository.SaveChengesAcync();
            var insertPlace = mapper.Map<PlacesToVisitDto>(finalPlace);
            return CreatedAtRoute("GetPlaceOfCity", new
            {
                placeid = finalPlace.Id,
                cityid = cityid
            }, insertPlace);
        }
        #endregion
        #region Edit
        [HttpPost("{placeid}")]
        public async Task<ActionResult> UpdatePlace(int cityid, PlaceUpdateViewModel p, int placeid)
        {
            if (!await cityRepository.CityExisitsAcync(cityid))
            {
                return NotFound();
            }
            var place=await cityRepository.GetPlaceOfCityAcync(cityid,placeid);
            if(place == null)
            {
                return NotFound();
            }
            mapper.Map(p,place);
            await cityRepository.SaveChengesAcync();
            return NoContent();

        }
        #endregion
        [HttpPatch("{placeid}/{a}")]
        public async Task<ActionResult> UpdatePlacePath(int a, int cityid,
            JsonPatchDocument<PlaceUpdateViewModel> patchDocument, int placeid)
        {
            if (!await cityRepository.CityExisitsAcync(cityid))
            {
                return NotFound();
            }
            var place = await cityRepository.GetPlaceOfCityAcync(cityid, placeid);
            if (place == null)
            {
                return NotFound();
            }
            var placeToPach=mapper.Map<PlaceUpdateViewModel>(place);
            patchDocument.ApplyTo(placeToPach,ModelState);
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            if(!TryValidateModel(patchDocument))
            {
                return BadRequest(ModelState);
            }
            mapper.Map(placeToPach,place);
            
            await cityRepository.SaveChengesAcync();
            return NoContent();

        }
        [HttpDelete("{placeid}")]
        public async Task<ActionResult> Delete(int placeid, int cityid)
        {
            //find city
            
            if(!await cityRepository.CityExisitsAcync(cityid))
                return NotFound();

            //find place
            var place = await cityRepository.GetPlaceOfCityAcync(cityid, placeid);
            if (place == null)
                return NotFound();
            //remove place
             cityRepository.DeleteAcync(place);
            await cityRepository.SaveChengesAcync();
            _mailService.Send("Information", $"place of city{place.Name} with id{placeid} is deleted");

            return NoContent();
        }
    }
}
