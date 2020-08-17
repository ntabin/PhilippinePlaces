namespace PhilippinePlaces.Entities
{
    using Newtonsoft.Json;

    public class BarangayEntity : Place
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("brgyDesc")]
        public override string Name { get; set; }

        [JsonProperty("brgyCode")]
        public override string Code { get; set; }

        [JsonProperty("regCode")]
        public string RegionCode { get; set; }

        [JsonProperty("provCode")]
        public string ProvinceCode { get; set; }

        [JsonProperty("citymunCode")]
        public string CityCode { get; set; }
    }
}
