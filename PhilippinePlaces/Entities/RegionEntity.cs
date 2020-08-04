namespace PhilippinePlaces.Entities
{
    using Newtonsoft.Json;

    public class RegionEntity
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("psgcCode")]
        public string PsgcCode { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("provinces")]
        public ProvinceEntity[] Provinces { get; set; }
    }
}
