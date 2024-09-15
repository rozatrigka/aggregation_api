using AggregationAPI.Integration.WeatherApi.DependencyInjection;
using AggregationAPI.Core.DependencyInjection;
using AggregationAPI.Integration.NewsApi.DependencyInjection;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        ConfigureServices(builder);

        BuildApp(builder);
    }

    private static WebApplicationBuilder ConfigureServices(WebApplicationBuilder builder) 
    {
        builder.Services.AddNewsApiServices(builder.Configuration);
        builder.Services.AddWeatherServices(builder.Configuration);
        builder.Services.AddCoreServices();



        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        return builder;
    }

    private static WebApplication BuildApp(WebApplicationBuilder builder) 
    {
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();

        return app;
    }
}