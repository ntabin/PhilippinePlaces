namespace PhilippinePlaces.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using PhilippinePlaces.Extensions;
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
        [Route("")]
        public IActionResult GetCities([FromQuery] GetCitiesWebRequest webRequest)
        {
            var cities = this.placesProvider.GetCities().Where(a => a.ProvinceCode == webRequest.Province).AsPlaceEntity();
            if (!webRequest.IncludeBarangays)
            {
                return new OkObjectResult(cities);
            }

            var barangays = from c in cities
                            select new { 
                                Code = c.Code,
                                Name = c.Name,
                                Barangays = this.placesProvider.GetBarangays().Where(a => a.CityCode == c.Code).AsPlaceEntity()
                            };

            return new OkObjectResult(barangays);

        }
    }
}
