﻿namespace PhilippinePlaces.Messages
{
    using System.ComponentModel.DataAnnotations;
    using Newtonsoft.Json;

    public class GetCitiesWebRequest
    {
        [JsonProperty("province")]
        [Required]
        public string Province { get; set; }
    }
}
