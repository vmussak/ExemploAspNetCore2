using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiExemplo.Api.Middlewares
{
    public static class ExceptionMiddleware
    {
        public static void UseExceptionFilter(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(builder =>
            {
                builder.Run(context =>
                {
                    var exception = context.Features.Get<IExceptionHandlerFeature>();
                    if (exception != null)
                    {
                        context.Response.Headers.Add("Content-Type", "application/json");
                        context.Response.WriteAsync(JsonConvert.SerializeObject(new { content = "Deu pau" }));
                    }

                    return Task.CompletedTask;
                });
            });
        }
    }
}
