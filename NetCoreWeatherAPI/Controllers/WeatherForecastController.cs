using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NetCoreWeatherAPI.Commands;
using NetCoreWeatherAPI.Handlers;

namespace NetCoreWeatherAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WeatherForecastController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet, Route("{city?}")]
        public async Task<IActionResult> Get([FromRoute] String city)
        {
            var query = new GetWeatherQuery
            {
                City = city
            };

            var result = await _mediator.Send(query);

            return Ok(result);
        }
    }
}
