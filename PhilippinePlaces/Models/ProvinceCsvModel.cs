namespace PhilippinePlaces.Models
{
    using Newtonsoft.Json;

    public class ProvinceCsvModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("psgcCode")]
        public string PsgcCode { get; set; }

        [JsonProperty("provDesc")]
        public string Name { get; set; }

        [JsonProperty("provCode")]
        public string Code { get; set; }

        [JsonProperty("regCode")]
        public string RegionCode { get; set; }
    }
}
