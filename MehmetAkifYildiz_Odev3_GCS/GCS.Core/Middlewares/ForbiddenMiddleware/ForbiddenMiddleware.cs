using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCS.Core.Middlewares.ForbiddenMiddleware
{
    public class ForbiddenMiddleware
    {
        private readonly RequestDelegate _next;
        public ForbiddenMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            var id = context.GetRouteData().Values["id"];
            if (context.Request.Path==$"/vehicles/{id}")
            {
                context.Response.StatusCode = 403;
                context.Response.ContentType = "text/plain";
                await context.Response.WriteAsync("Forbidden Zone from Middleware!!!");
                return;
            }
            await _next.Invoke(context);
        }
    }
}
