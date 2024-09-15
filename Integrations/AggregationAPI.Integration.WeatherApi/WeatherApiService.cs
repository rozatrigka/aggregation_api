using AggregationAPI.Integration.WeatherApi.Constants;
using AggregationAPI.Integration.WeatherApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace AggregationAPI.Integration.WeatherApi
{
    public class WeatherApiService : IWeatherApiService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public WeatherApiService(HttpClient httpClient, string apiKey) 
        {
            _httpClient = httpClient; 
            _apiKey = apiKey;
        }

        public async Task<WeatherResponse> GetPolutionAirAsync(WeatherRequest request) 
        {
            var requestUrl = CreateRequestUrl(request);

            var response = await _httpClient.GetAsync(requestUrl);
            response.EnsureSuccessStatusCode();


            var weather = await response.Content.ReadFromJsonAsync<WeatherResponse>();

            return weather;
        }

        private string CreateRequestUrl(WeatherRequest request) 
        {
            var strb = new StringBuilder();

            strb.Append(Endpoints.GetAirPolution);
            strb.Append("?");

            if (request.Latitude != null) 
            {
                strb.Append("lat=");
                strb.Append(request.Latitude);
            }

            if (request.Longitude != null)
            {
                strb.Append("&");
                strb.Append("lon=");
                strb.Append(request.Longitude);
            }

            if (_apiKey!= null)
            {
                strb.Append("&");
                strb.Append("appid=");
                strb.Append(_apiKey);
            }

            return strb.ToString();
        }
    }
}
