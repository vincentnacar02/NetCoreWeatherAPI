using FluentValidation;
using NetCoreWeatherAPI.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreWeatherAPI.Validator
{
    public class GetWeatherValidator : AbstractValidator<GetWeatherQuery>
    {
        public GetWeatherValidator()
        {
            RuleFor(g => g.City).NotEmpty().WithMessage("City is required.");
        }
    }
}
