namespace PhilippinePlaces.Models
{
    using Newtonsoft.Json;

    public class CityCsvModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("psgcCode")]
        public string PsgcCode { get; set; }

        [JsonProperty("citymunDesc")]
        public string Name { get; set; }

        [JsonProperty("citymunCode")]
        public string Code { get; set; }

        [JsonProperty("regCode")]
        public string RegionCode { get; set; }

        [JsonProperty("provCode")]
        public string ProvinceCode { get; set; }
    }
}
