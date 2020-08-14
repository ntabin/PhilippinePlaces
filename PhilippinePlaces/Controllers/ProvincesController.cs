namespace PhilippinePlaces.Controllers
{
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using PhilippinePlaces.Messages;
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
        public IActionResult GetProvinces([FromQuery] GetProvincesWebRequest webRequest)
        {
            var provinces = (from p in this.placesProvider.GetProvinces()
                             where p.RegionCode == webRequest.Region
                             select new
                             {
                                 Code = p.Code,
                                 Name = p.Name
                             }).Distinct();
            return new OkObjectResult(provinces);
        }
    }
}
