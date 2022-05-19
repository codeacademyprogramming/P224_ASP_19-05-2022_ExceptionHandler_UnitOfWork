using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Shop.Service.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Api.Extentions
{
    public static class Extention
    {
        public static void ExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(errors =>
            {
                errors.Run(async context =>
                {
                    var feature = context.Features.Get<IExceptionHandlerPathFeature>();

                    int statusCode = 500;
                    string errorMessage = "Internal Server Error";

                    if (feature != null)
                    {
                        if (feature.Error is ItemNotFoundException)
                        {
                            statusCode = 404;
                        }
                        else if (feature.Error is IdIsNullException)
                        {
                            statusCode = 400;
                        }

                        errorMessage = feature.Error.Message;

                        var error = new
                        {
                            statusCode = statusCode,
                            errorMessage = errorMessage
                        };

                        context.Response.StatusCode = statusCode;
                        await context.Response.WriteAsync(JsonConvert.SerializeObject(error));
                    }
                });
            });
        }
    }
}
