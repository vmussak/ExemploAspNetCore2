using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace WebApiExemplo.Api.Middlewares
{
    public static class NotFoundMiddleware
    {
        public static void UseNotFound(this IApplicationBuilder app)
        {
            app.UseStatusCodePages(new StatusCodePagesOptions
            {
                HandleAsync = ctx =>
                {
                    if (ctx.HttpContext.Response.StatusCode == 404)
                    {
                        ctx.HttpContext.Response.Headers.Add("Content-Type", "application/json");
                        ctx.HttpContext.Response.WriteAsync(JsonConvert.SerializeObject(new { content = "Recurso não encontrado" }));
                    }

                    return Task.CompletedTask;
                }
            });
        }
    }
}
