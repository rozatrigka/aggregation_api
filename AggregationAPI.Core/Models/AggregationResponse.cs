using AggregationAPI.Integration.NewsApi.Models;
using AggregationAPI.Integration.WeatherApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AggregationAPI.Core.Models
{
    public class AggregationResponse
    {
        public ArticleResponse? Articles { get; set; }

        public WeatherResponse? Polution { get; set; }

    }
}
