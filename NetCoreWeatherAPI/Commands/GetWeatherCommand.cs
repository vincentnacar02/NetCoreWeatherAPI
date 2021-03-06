using MediatR;
using NetCoreWeatherAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreWeatherAPI.Commands
{
    public class GetWeatherCommand : IRequest<Weather>
    {
        public String City { get; set; }
    }
}
