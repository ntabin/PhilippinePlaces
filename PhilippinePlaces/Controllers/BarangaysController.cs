namespace PhilippinePlaces.Controllers
{
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using PhilippinePlaces.Extensions;
    using PhilippinePlaces.Filters;
    using PhilippinePlaces.Messages;
    using PhilippinePlaces.Providers;

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
        public IActionResult GetBarangays([FromQuery] GetBarangaysWebRequest webRequest)
        {
            var barangays = this.placesProvider.GetBarangays().Where(a => a.CityCode == webRequest.City).AsPlaceEntity();
            return new OkObjectResult(barangays);
        }
    }
}
