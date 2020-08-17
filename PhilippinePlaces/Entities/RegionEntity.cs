namespace PhilippinePlaces.Entities
{
    using Newtonsoft.Json;

    public class RegionEntity : Place
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("psgcCode")]
        public string PsgcCode { get; set; }

        [JsonProperty("regDesc")]
        public override string Name { get; set; }

        [JsonProperty("regCode")]
        public override string Code { get; set; }
    }
}
