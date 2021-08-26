using System;
using Swashbuckle.AspNetCore.Annotations;

namespace swaggerWebapi1
{
    [SwaggerSchema(Required = new [] { nameof(TemperatureC), nameof(Summary) })]
    public class WeatherForecast
    {
        [SwaggerSchema(Description = "The timestamp of the forecast.")]
        public DateTime Date { get; set; }

        [SwaggerSchema(Description = "The temperature in degrees Celcius.")]

        public int TemperatureC { get; set; }

        [SwaggerSchema(Description = "The temperature in degrees Fahrenheit.", ReadOnly = true)]
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        [SwaggerSchema(Description = "A summary of the forecast.")]
        public string Summary { get; set; }
    }
}
