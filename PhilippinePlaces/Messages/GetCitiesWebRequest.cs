namespace PhilippinePlaces.Messages
{
    using System.ComponentModel.DataAnnotations;
    using Newtonsoft.Json;

    public class GetCitiesWebRequest
    {
        [JsonProperty("province")]
        [Required(ErrorMessage = "Province is required")]
        public string ProvinceCode { get; set; }
    }
}
