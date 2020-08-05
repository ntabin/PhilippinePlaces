namespace PhilippinePlaces.Models
{
    using Newtonsoft.Json;

    public class BarangayCsvModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("brgyDesc")]
        public string Name { get; set; }

        [JsonProperty("brgyCode")]
        public string Code { get; set; }

        [JsonProperty("regCode")]
        public string RegionCode { get; set; }

        [JsonProperty("provCode")]
        public string ProvinceCode { get; set; }

        [JsonProperty("citymunCode")]
        public string CityCode { get; set; }
    }
}
