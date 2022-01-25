using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCS.Core.Middlewares.ForbiddenMiddleware
{
    public static class ForbiddenMiddlewareExtension
    {
        public static IApplicationBuilder UseForbiddenMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ForbiddenMiddleware>();
        }
    }
}
