namespace PhilippinePlaces.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using PhilippinePlaces.Filters;
    using PhilippinePlaces.Messages;
    using PhilippinePlaces.Providers;
    using System.Linq;

    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class CitiesController : ControllerBase
    {
        private readonly IPlacesProvider placesProvider;

        public CitiesController(IPlacesProvider placesProvider)
        {
            this.placesProvider = placesProvider;
        }

        [ServiceFilter(typeof(ValidateModelStateAttribute))]
        [HttpGet]
        public IActionResult GetCities([FromQuery] GetCitiesWebRequest webRequest)
        {
            var cities = (from p in this.placesProvider.GetPlaces()
                          where p.ProvinceCode == webRequest.ProvinceCode
                          select new
                          {
                              Code = p.CityCode,
                              Name = p.CityName
                          }).Distinct();
            return new OkObjectResult(cities);
        }
    }
}
