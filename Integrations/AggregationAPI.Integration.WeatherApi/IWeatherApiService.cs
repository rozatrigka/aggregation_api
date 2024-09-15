using AggregationAPI.Integration.WeatherApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AggregationAPI.Integration.WeatherApi
{
    public interface IWeatherApiService
    {
        Task<WeatherResponse> GetPolutionAirAsync(WeatherRequest request);
    }
}
