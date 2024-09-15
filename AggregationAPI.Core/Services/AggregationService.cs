using AggregationAPI.Core.Abstractions;
using AggregationAPI.Core.Models;
using AggregationAPI.Integration.NewsApi;
using AggregationAPI.Integration.NewsApi.Models;
using AggregationAPI.Integration.WeatherApi;
using AggregationAPI.Integration.WeatherApi.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AggregationAPI.Core.Services
{
    public class AggregationService : IAggregationService
    {
        private readonly INewsApiService _newsApiService;
        private readonly IWeatherApiService _weatherApiService;
        private readonly ILogger<AggregationService> _logger;

        public AggregationService(INewsApiService newsApiService,IWeatherApiService weatherApiService, ILogger<AggregationService> logger)
        {
            _newsApiService = newsApiService;
            _weatherApiService = weatherApiService;
            _logger = logger;
        }

        public async Task<AggregationResponse> GetAsync(AggregationRequest request)
        {
            var article = await GetNewsAsync(request.News);
            var airPolution = await GetPolutionAirAsync(request.Polution);

            var aggregationResponse = new AggregationResponse() 
            { 
                Articles = article,
                Polution = airPolution,
            };

            return aggregationResponse;
        }

        private async Task<WeatherResponse> GetPolutionAirAsync(PolutionRequest? request) 
        {
            try
            {
                if (request == null) 
                {
                    return null;
                }

                var weatherRequest = new WeatherRequest()
                {
                    Latitude = request.Latitude,
                    Longitude = request.Longitude
                };
                var response = await _weatherApiService.GetPolutionAirAsync(weatherRequest);

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        private async Task<ArticleResponse> GetNewsAsync(NewsRequest? request)
        {
            try
            {
                if (request == null) 
                {
                    return null;
                }

                var articleRequest = new ArticleRequest()
                {
                    Question = request.Question
                };
                var articles = await _newsApiService.GetArticlesAsync(articleRequest);

                return articles;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }
    }
}
