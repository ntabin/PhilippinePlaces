namespace PhilippinePlaces.Entities
{
    using Newtonsoft.Json;

    public class ProvinceEntity : Place
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("psgcCode")]
        public string PsgcCode { get; set; }

        [JsonProperty("provDesc")]
        public override string Name { get; set; }

        [JsonProperty("provCode")]
        public override string Code { get; set; }

        [JsonProperty("regCode")]
        public string RegionCode { get; set; }
    }
}
