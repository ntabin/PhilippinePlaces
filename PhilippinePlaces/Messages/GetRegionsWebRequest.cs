

namespace PhilippinePlaces.Messages
{
    using Newtonsoft.Json;

    public class GetRegionsWebRequest
    {
        [JsonProperty("includeProvinces")]
        public bool IncludeProvinces { get; set; } = false;

        [JsonProperty("includeCities")]
        public bool IncludeCities { get; set; } = false;

        [JsonProperty("includeBarangays")]
        public bool IncludeBarangays { get; set; } = false;

        [JsonProperty("region")]
        public string Region { get;set; }
    }
}
