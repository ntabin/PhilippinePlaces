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
        [Route("")]
        public IActionResult GetCities([FromQuery] GetCitiesWebRequest webRequest)
        {
            var cities = (from p in this.placesProvider.GetCities()
                          where p.ProvinceCode == webRequest.Province
                          select new
                          {
                              Code = p.Code,
                              Name = p.Name
                          }).Distinct();
            return new OkObjectResult(cities);
        }
    }
}
