using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AggregationAPI.Integration.WeatherApi.Models
{
    public class Main
    {
        [JsonPropertyName("aqi")]
        public int Aqi { get; set; }
    }
}
