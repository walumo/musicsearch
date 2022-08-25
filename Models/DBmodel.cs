using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace musicsearch.Models
{
    public class DBmodel
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "Artist")]
        public string Artist { get; set; }

        [JsonProperty(PropertyName = "Song")]
        public string Song { get; set; }

        [JsonProperty(PropertyName = "Latitude")]
        public string? Latitude { get; set; } = "0";

        [JsonProperty(PropertyName = "Longitude")]
        public string? Longitude { get; set; } = "0";


    }
}
