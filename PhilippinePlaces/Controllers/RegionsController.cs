
namespace PhilippinePlaces.Controllers
{
    using System.Linq;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using PhilippinePlaces.Providers;

    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class RegionsController : ControllerBase
    {
        private readonly IPlacesProvider placesProvider;

        public RegionsController(IPlacesProvider placesProvider)
        {
            this.placesProvider = placesProvider;
        }

        [HttpGet]
        [Route("")]
        public IActionResult GetRegions([FromQuery]string regionCode = null)
        {
            var places = this.placesProvider.GetPlaces();
            var regions = (from p in places
                           where p.RegionCode == regionCode || regionCode == null
                           select new
                           {
                               Code = p.RegionCode,
                               Name = p.RegionName
                           }).Distinct();
            return new OkObjectResult(regions);
        }

        [HttpGet]
        [Route("provinces")]
        public IActionResult GetProvincesAndRegions()
        {
            var places = this.placesProvider.GetPlaces();
            var raw = (from p in places
                                        select new
                                        {
                                            RegionCode = p.RegionCode,
                                            RegionName = p.RegionName,
                                            ProvinceCode = p.ProvinceCode,
                                            ProvinceName = p.ProvinceName
                                        }).Distinct();

            var regionsWithProvinces = from rp in raw
                    select new
                    {
                        Code = rp.RegionCode,
                        Name = rp.RegionName,
                        Provinces = from province in raw
                                    where province.RegionCode == rp.RegionCode
                                    select new
                                    {
                                        Code = province.ProvinceCode,
                                        Name = province.ProvinceName
                                    }
                    };
            return new OkObjectResult(regionsWithProvinces);
        }
    }
}
