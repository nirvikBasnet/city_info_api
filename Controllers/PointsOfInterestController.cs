using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityInfo.Models;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.Controllers
{
    [ApiController]
    [Route("api/cities/{cityId}/pointsofinterest")]
    public class PointsOfInterestController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<PointOfInterestDto>> GetPointOfInterest(int cityId){
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c=>c.Id==cityId);

            if(city == null){
                return NotFound();
            }

            return Ok(city.PointsOfInterest);
        }

        [HttpGet("{pointOfInterestId}")]
        public ActionResult<PointOfInterestDto> GetPointOfInterest(int cityId,int pointOfInterestId){
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c=>c.Id==cityId);

            if(city == null){
                return NotFound();
            }

            var pointOfInterest = city.PointsOfInterest?.FirstOrDefault(c => c.Id == pointOfInterestId);
            if(pointOfInterest ==null){
                return NotFound();
            }

            return Ok(pointOfInterest);
        }
    }
}