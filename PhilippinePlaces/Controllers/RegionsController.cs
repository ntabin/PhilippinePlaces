namespace PhilippinePlaces.Controllers
{
    using System.Linq;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using PhilippinePlaces.Entities;
    using PhilippinePlaces.Extensions;
    using PhilippinePlaces.Filters;
    using PhilippinePlaces.Messages;
    using PhilippinePlaces.Models;
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

        [ServiceFilter(typeof(ValidateModelStateAttribute))]
        [HttpGet]
        [Route("")]
        public IActionResult GetRegions([FromQuery] GetRegionsWebRequest webRequest)
        {
            var regions = from r in this.placesProvider.GetRegions()
                          where r.Code == webRequest.Region || webRequest.Region == null
                          select new PlaceEntity
                          {
                              Code = r.Code,
                              Name = r.Name
                          };

            if (!webRequest.IncludeProvinces)
            {
                return new OkObjectResult(regions);
            }

            var provinces = from r in regions
                            select new RegionWithProvincesWebModel
                            {
                                Code = r.Code,
                                Name = r.Name,
                                Provinces = this.placesProvider.GetProvinces().Where(a => a.RegionCode == r.Code).AsModel()
                            };

            if (!webRequest.IncludeCities)
            {
                return new OkObjectResult(provinces);
            }

            var cities = from r in regions
                         select new RegionWithProvincesAndCitiesWebModel
                         {
                             Code = r.Code,
                             Name = r.Name,
                             Provinces = from p in this.placesProvider.GetProvinces()
                                         where p.RegionCode == r.Code
                                         select new ProvinceWithCitiesWebModel
                                         {
                                             Code = p.Code,
                                             Name = p.Name,
                                             Cities = this.placesProvider.GetCities().Where(a => a.ProvinceCode == p.Code).AsModel()
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
                                                         select new CityWithBarangaysWebModel
                                                         {
                                                             Code = c.Code,
                                                             Name = c.Name,
                                                             Barangays = this.placesProvider.GetBarangays().Where(a => a.CityCode == c.Code).AsModel()
                                                         }
                                            }
                            };
            return new OkObjectResult(barangays);
        }
    }
}
