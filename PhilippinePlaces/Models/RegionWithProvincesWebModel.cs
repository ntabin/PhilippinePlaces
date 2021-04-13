namespace PhilippinePlaces.Models
{
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using PhilippinePlaces.Entities;

    public class RegionWithProvincesWebModel : PlaceModel
    {
        [JsonProperty("provinces")]
        public IEnumerable<PlaceModel> Provinces { get; set; }
    }
}
