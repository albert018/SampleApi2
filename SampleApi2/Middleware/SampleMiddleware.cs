using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using SampleApi2.Interface;
using SampleApi2.Implement;

namespace SampleApi2.Middleware
{
    public class SampleMiddleware
    {
        private readonly RequestDelegate _next;

        public SampleMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync (HttpContext context)
        {
            //await context.Response.WriteAsync("sampleMiddleware");
            await _next(context);
        }
    }
}
