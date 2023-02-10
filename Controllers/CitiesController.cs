using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityInfo.Models;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.Controllers
{   
    [ApiController]
    [Route("api/cities")] //template
    //if we put [controller] match the route to CitiesController, disadv for API
    public class CitiesController : ControllerBase //basic funcitonality controllers need
    //Controller : additional helper method to return views
    {
        [HttpGet]
        //Using ActionResult so that we can handle status easily
        public ActionResult<IEnumerable<CityDto>> GetCities(){
            List<CityDto> cities = CitiesDataStore.Current.Cities;
            return Ok(cities);
        }
        [HttpGet("{id}")]
        public ActionResult<CityDto> GetCity(int id){
            var cityToReturn =  CitiesDataStore.Current.Cities.FirstOrDefault(city=>city.Id==id);

            if(cityToReturn == null){
                return NotFound();
            }

            return Ok(cityToReturn);
        }
    }
}