using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AggregationAPI.Integration.WeatherApi.Models
{
    public class WeatherResponse
    {
        [JsonPropertyName("coord")]
        public Coordinates Coordinates { get; set; }

        [JsonPropertyName("list")]
        public CoordinateDetails[] CoordinateDetails { get; set; }
    }
}
