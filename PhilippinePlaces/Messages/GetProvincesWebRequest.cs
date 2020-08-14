namespace PhilippinePlaces.Messages
{
    using System.ComponentModel.DataAnnotations;
    using Newtonsoft.Json;

    public class GetProvincesWebRequest
    {
        [JsonProperty("region")]
        [Required]
        public string Region { get; set; }
    }
}
