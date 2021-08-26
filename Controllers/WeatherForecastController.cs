using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;

namespace swaggerWebapi1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Gets the current weather forecasts.
        /// </summary>
        /// <param name="count">Specifies the number of forecasts requested. (optional, default=5)</param>
        /// <remarks>
        /// Used to get weather forecasts. Caller may optionally specify how many forecasts are requested.
        /// The default is five (5).
        /// <pre>GET /weatherforecasts</pre>
        /// <pre>GET /weatherforecasts?count=3</pre>
        /// </remarks>
        /// <returns>The specified number of weather forecasts (default=5).</returns>
        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        [SwaggerOperation(
            OperationId = nameof(Get),
            Summary = "Gets weather forecasts",
            Description = "Gets a specified number of weather forecasts (default=5)",
            Tags = new [] { "Weather Forecasts" })]
        [SwaggerResponse(
            StatusCodes.Status200OK,
            Description = "A collection of weather forecasts",
            Type = typeof(IEnumerable<WeatherForecast>))]
        public IEnumerable<WeatherForecast> Get(
            [FromQuery, SwaggerParameter(Description = "optional number of forecasts", Required = false)] int count = 5)
        {
            var rng = new Random();
            return Enumerable.Range(1, count).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
