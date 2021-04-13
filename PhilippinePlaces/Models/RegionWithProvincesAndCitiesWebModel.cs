namespace PhilippinePlaces.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Newtonsoft.Json;

    public class RegionWithProvincesAndCitiesWebModel : PlaceModel
    {
        [JsonProperty("provinces")]
        public IEnumerable<ProvinceWithCitiesWebModel> Provinces { get; set; }
    }
}
