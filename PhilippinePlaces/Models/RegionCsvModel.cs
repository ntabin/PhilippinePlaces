namespace PhilippinePlaces.Models
{
    using Newtonsoft.Json;

    public class RegionCsvModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("psgcCode")]
        public string PsgcCode { get; set; }

        [JsonProperty("regDesc")]
        public string Name { get; set; }

        [JsonProperty("regCode")]
        public string Code { get; set; }
    }
}
