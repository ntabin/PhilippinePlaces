using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhilippinePlaces.Filters;
using PhilippinePlaces.Messages;
using PhilippinePlaces.Providers;

namespace PhilippinePlaces.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BarangaysController : ControllerBase
    {
        private readonly IPlacesProvider placesProvider;

        public BarangaysController(IPlacesProvider placesProvider)
        {
            this.placesProvider = placesProvider;
        }

        [ServiceFilter(typeof(ValidateModelStateAttribute))]
        [HttpGet]
        [Route("")]
        public IActionResult GetCities([FromQuery] GetBarangaysWebRequest webRequest)
        {
            var cities = (from p in this.placesProvider.GetBarangays()
                          where p.CityCode == webRequest.City
                          select new
                          {
                              Code = p.Code,
                              Name = p.Name
                          }).Distinct();
            return new OkObjectResult(cities);
        }
    }
}
