using FluentValidation;
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

        public class GetWeatherHandler : IRequestHandler<GetWeatherQuery, Weather>
        {
            private readonly IValidatorFactory _validationFactory;

            public GetWeatherHandler(IValidatorFactory validationFactory)
            {
                _validationFactory = validationFactory;
            }

            public Task<Weather> Handle(GetWeatherQuery request, CancellationToken cancellationToken)
            {
                var validator = _validationFactory.GetValidator<GetWeatherQuery>();

                var result = validator.Validate(request);
                if (result != null && !result.IsValid)
                {
                    throw new ValidationException(result.Errors);
                }

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
