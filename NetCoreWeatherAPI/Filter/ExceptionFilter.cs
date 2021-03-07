﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace NetCoreWeatherAPI.Filter
{
    public class ExceptionFilter : Attribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is Exception)
            {
                context.Result = new ObjectResult(context.Exception.Message);
                context.HttpContext.Response.StatusCode = 400;
                context.Exception = null;
            }
        }
    }
}
