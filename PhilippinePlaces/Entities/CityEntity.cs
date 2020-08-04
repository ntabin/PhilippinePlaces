namespace PhilippinePlaces.Entities
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class CityEntity
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("psgcCode")]
        public string PsgcCode { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("barangays")]
        public IEnumerable<BarangayEntity> Barangays { get; set; }
    }
}
