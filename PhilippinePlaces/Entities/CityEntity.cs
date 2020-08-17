namespace PhilippinePlaces.Entities
{
    using Newtonsoft.Json;

    public class CityEntity : Place
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("psgcCode")]
        public string PsgcCode { get; set; }

        [JsonProperty("citymunDesc")]
        public override string Name { get; set; }

        [JsonProperty("citymunCode")]
        public override string Code { get; set; }

        [JsonProperty("regCode")]
        public string RegionCode { get; set; }

        [JsonProperty("provCode")]
        public string ProvinceCode { get; set; }
    }
}
