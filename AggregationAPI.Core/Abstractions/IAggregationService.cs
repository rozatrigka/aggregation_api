using AggregationAPI.Core.Models;
using AggregationAPI.Integration.NewsApi.Models;
using AggregationAPI.Integration.WeatherApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AggregationAPI.Core.Abstractions
{
    public interface IAggregationService
    {
        Task<AggregationResponse> GetAsync(AggregationRequest request);
    }
}
