using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace AggregationAPI.Integration.WeatherApi.DependencyInjection
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddWeatherServices(this IServiceCollection services, IConfiguration configuration) 
        {
            var client = new HttpClient();
            
            var baseUri = configuration.GetSection("WeatherApi:BaseUri").Value;
            client.BaseAddress = new Uri(baseUri);

            var apiKey = configuration.GetSection("WeatherApi:AppId").Value;

            //concrete class
            services.AddScoped<IWeatherApiService>( i => new WeatherApiService(client, apiKey));
            
            return services;
        }
    }
}
