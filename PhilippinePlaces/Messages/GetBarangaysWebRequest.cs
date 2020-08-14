namespace PhilippinePlaces.Messages
{
    using System.ComponentModel.DataAnnotations;
    using Newtonsoft.Json;

    public class GetBarangaysWebRequest
    {
        [JsonProperty("city")]
        [Required]
        public string City { get; set; }
    }
}
