namespace PhilippinePlaces.Controllers
{
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using PhilippinePlaces.Providers;

    [Route("api/[controller]")]
    [ApiController]
    public class ProvincesController : ControllerBase
    {
        private readonly IPlacesProvider placesProvider;

        public ProvincesController(IPlacesProvider placesProvider)
        {
            this.placesProvider = placesProvider;
        }

        [HttpGet]
        [Route("")]
        public IActionResult GetProvinces([FromQuery] string region = null)
        {
            var provinces = (from p in this.placesProvider.GetPlaces()
                             where p.RegionCode == region || region == null
                             select new
                             {
                                 Code = p.ProvinceCode,
                                 Name = p.ProvinceName
                             }).Distinct();
            return new OkObjectResult(provinces);
        }
    }
}
