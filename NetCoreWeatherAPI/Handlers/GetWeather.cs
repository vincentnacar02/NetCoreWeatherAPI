using MediatR;
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

        public class Query : IRequest<Result>
        {
            public String City { get; set; }
        }

        public class Result
        {
            public String City { get; set; }

            public DateTime Date { get; set; }

            public int TemperatureC { get; set; }

            public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

            public string Summary { get; set; }
        }

        public class GetWeatherHandler : IRequestHandler<Query, Result>
        {
            public Task<Result> Handle(Query request, CancellationToken cancellationToken)
            {
                var rng = new Random();
                return Task.FromResult(new Result
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
