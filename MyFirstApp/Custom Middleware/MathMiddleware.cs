using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace MyFirstApp.Custom_Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class MathMiddleware
    {
        private readonly RequestDelegate _next;

        public MathMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var num1 = context.Request.Query["firstNumber"];
            var num2 = context.Request.Query["secondNumber"];
            var opr = context.Request.Query["operation"];

            //var reader = new StreamReader(context.Request.Body);
            //var body = await reader.ReadToEndAsync();

            //var dictqry = QueryHelpers.ParseQuery(body);

            //var num1 = dictqry["firstNumber"];
            //var num2 = dictqry["secondNumber"];
            //var opr = dictqry["operation"];

            var res = 0.0;
            switch (opr)
            {
                case "add":
                    res = Convert.ToInt32(num1) + Convert.ToInt32(num2);
                    break;
                case "sub":
                    res = Convert.ToInt32(num1) - Convert.ToInt32(num2);
                    break;
                case "mul":
                    res = Convert.ToInt32(num1) * Convert.ToInt32(num2);
                    break;
                case "div":
                    res = Convert.ToDouble(num1) / Convert.ToDouble(num2);
                    break;
                default:
                    res = 0.0;
                    break;
            }

            await context.Response.WriteAsync($"{res}\n");

            await _next(context);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MathMiddlewareExtensions
    {
        public static IApplicationBuilder UseMathMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MathMiddleware>();
        }
    }
}
