using AggregationAPI.Core.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AggregationAPI.Core.Abstractions;

namespace AggregationAPI.Core.DependencyInjection
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services) 
        {
            services.AddScoped<IAggregationService, AggregationService>();

            return services;
        }
    }
}
