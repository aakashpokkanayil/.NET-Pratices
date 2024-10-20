using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace MyFirstApp.Custom_Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class CustomMiddleware2
    {
        private readonly RequestDelegate _next;

        public CustomMiddleware2(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            await httpContext.Response.WriteAsync("this is conventional method of creating middleware: start\n");
            await _next(httpContext);
            await httpContext.Response.WriteAsync("this is conventional method of creating middleware: end\n");

        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class CustomMiddleware2Extensions
    {
        public static IApplicationBuilder UseCustomMiddleware2(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomMiddleware2>();
        }
    }
}
