namespace PhilippinePlaces.Entities
{
    using Newtonsoft.Json;

    public class PlaceEntity
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
