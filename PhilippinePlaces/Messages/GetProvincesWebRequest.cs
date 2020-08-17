namespace PhilippinePlaces.Messages
{
    using System.ComponentModel.DataAnnotations;
    using Newtonsoft.Json;

    public class GetProvincesWebRequest
    {
        [JsonProperty("includeCities")]
        public bool IncludeCities { get; set; } = false;

        [JsonProperty("includeBarangays")]
        public bool IncludeBarangays { get; set; } = false;

        [JsonProperty("region")]
        [Required]
        public string Region { get; set; }
    }
}
