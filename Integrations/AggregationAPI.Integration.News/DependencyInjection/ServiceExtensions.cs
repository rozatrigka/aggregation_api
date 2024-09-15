using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AggregationAPI.Integration.NewsApi.DependencyInjection
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddNewsApiServices(this IServiceCollection services, IConfiguration configuration) 
        {
            var client = new HttpClient();
            var baseUri = configuration.GetSection("NewsApi:BaseUri").Value;
            client.BaseAddress = new Uri(baseUri);

            var apiKey = configuration.GetSection("NewsApi:ApiKey").Value;
            
            services.AddScoped<INewsApiService>( i => new NewsApiService(client, apiKey));

            return services;
        }
    }
}
