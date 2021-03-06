using MediatR;
using NetCoreWeatherAPI.Commands;
using NetCoreWeatherAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NetCoreWeatherAPI.Handlers
{
    public class GetWeather
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public class GetWeatherHandler : IRequestHandler<GetWeatherCommand, Weather>
        {
            public Task<Weather> Handle(GetWeatherCommand request, CancellationToken cancellationToken)
            {
                var rng = new Random();
                return Task.FromResult(new Weather
                {
                    City = request.City,
                    Date = DateTime.Now,
                    TemperatureC = rng.Next(-20, 55),
                    Summary = Summaries[rng.Next(Summaries.Length)]
                });
            }
        }
    }
}
