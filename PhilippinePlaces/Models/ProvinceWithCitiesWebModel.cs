namespace PhilippinePlaces.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using PhilippinePlaces.Entities;

    public class ProvinceWithCitiesWebModel : PlaceModel
    {
        [JsonProperty("cities")]
        public IEnumerable<PlaceModel> Cities { get; set; }
    }
}
