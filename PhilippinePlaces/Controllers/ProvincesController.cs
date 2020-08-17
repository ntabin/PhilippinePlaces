namespace PhilippinePlaces.Controllers
{
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using PhilippinePlaces.Extensions;
    using PhilippinePlaces.Filters;
    using PhilippinePlaces.Messages;
    using PhilippinePlaces.Providers;

    [ServiceFilter(typeof(ValidateModelStateAttribute))]
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
            var provinces = this.placesProvider.GetProvinces().Where(a => a.RegionCode == webRequest.Region).AsPlaceEntity();
            if (!webRequest.IncludeCities)
            {
                return new OkObjectResult(provinces);
            }

            var cities = from p in provinces
                         select new
                         {
                             Code = p.Code,
                             Name = p.Name,
                             Cities = this.placesProvider.GetCities().Where(a => a.ProvinceCode == p.Code).AsPlaceEntity()
                         };
            if (!webRequest.IncludeBarangays)
            {
                return new OkObjectResult(cities);
            }

            var barangays = from p in provinces
                            select new
                            {
                                Code = p.Code,
                                Name = p.Name,
                                Cities = from c in this.placesProvider.GetCities()
                                         where c.ProvinceCode == p.Code
                                         select new
                                         {
                                             Code = c.Code,
                                             Name = c.Name,
                                             Barangays = this.placesProvider.GetBarangays().Where(a => a.CityCode == c.Code).AsPlaceEntity()
                                         }
                            };

            return new OkObjectResult(barangays);
        }
    }
}
