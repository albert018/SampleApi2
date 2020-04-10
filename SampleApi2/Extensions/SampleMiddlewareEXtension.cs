using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SampleApi2.Middleware;

namespace SampleApi2.Extensions
{
    public static class SampleMiddlewareEXtension
    {
        public static IApplicationBuilder UseSampleMiddleware(this IApplicationBuilder builder)
        {
            //return builder.Map("/test/middleware", _ => _.UseMiddleware<SampleMiddleware>());
            //return builder.MapWhen(_ => _.Request.Method.ToUpper() == "POST", 
            //_ => _.UseMiddleware<SampleMiddleware>());
            return builder.UseMiddleware<SampleMiddleware>();
        }
    }
}
