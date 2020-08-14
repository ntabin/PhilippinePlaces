
namespace PhilippinePlaces.Controllers
{
    using System.Linq;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using PhilippinePlaces.Extensions;
    using PhilippinePlaces.Messages;
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
        [Route("{regionCode?}")]
        public IActionResult GetRegions([FromQuery] GetRegionsWebRequest webRequest, string regionCode)
        {
            var regions = from r in this.placesProvider.GetRegions()
                          where r.Code == regionCode || regionCode == null
                          select new
                          {
                              Code = r.Code,
                              Name = r.Name
                          };

            if (!webRequest.IncludeProvinces)
            {
                return new OkObjectResult(regions);
            }

            var provinces = from r in regions
                            select new
                            {
                                Code = r.Code,
                                Name = r.Name,
                                Provinces = this.placesProvider.GetProvinces().Where(a => a.RegionCode == regionCode).AsPlaceEntity()

                            };

            if (!webRequest.IncludeCities)
            {
                return new OkObjectResult(provinces);
            }

            var cities = from r in regions
                         select new
                         {
                             Code = r.Code,
                             Name = r.Name,
                             Provinces = from p in this.placesProvider.GetProvinces()
                                         where p.RegionCode == r.Code
                                         select new
                                         {
                                             Code = p.Code,
                                             Name = p.Name,
                                             Cities = this.placesProvider.GetCities().Where(a => a.ProvinceCode == p.Code).AsPlaceEntity()
                                         }
                         };

            if (!webRequest.IncludeBarangays)
            {
                return new OkObjectResult(cities);
            }

            var barangays = from r in regions
                            select new
                            {
                                Code = r.Code,
                                Name = r.Name,
                                Provinces = from p in this.placesProvider.GetProvinces()
                                            where p.RegionCode == r.Code
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
                                            }
                            };
            return new OkObjectResult(barangays);
        }
    }
}
