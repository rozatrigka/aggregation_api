using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AggregationAPI.Integration.WeatherApi.Models
{
    public class CoordinateDetails
    {

        [JsonPropertyName("dt")]
        [Timestamp]
        public int Date { get; set; }

        [JsonPropertyName("main")]
        public Main Main { get; set; }

        [JsonPropertyName("components")]
        public Component Components { get; set; }
    }
}
