using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AggregationAPI.Integration.WeatherApi.Models
{
    public class WeatherRequest
    {
        public int Latitude { get; set; }
        public int Longitude { get; set; }
    }
}
