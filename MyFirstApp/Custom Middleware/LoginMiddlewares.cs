
using Microsoft.AspNetCore.WebUtilities;

namespace MyFirstApp.Custom_Middleware
{
    public class LoginMiddlewares : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var stream = new StreamReader(context.Request.Body);
            var body   = await stream.ReadToEndAsync();
            var dictbody = QueryHelpers.ParseQuery(body);
            var validEmail = "admin@example.com";
            var validPassword = "admin1234";
            try
            {
                if (dictbody["email"] == validEmail && dictbody["password"] == validPassword)
                {
                    context.Response.StatusCode = 200;
                    await context.Response.WriteAsync("Login sucessfully \n");

                }
                else
                {
                    context.Response.StatusCode = 400;
                    await context.Response.WriteAsync("Invalid Credentials \n");
                }
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync("Invalid Credentials \n");
            }
            await next(context);
        }
    }

    public static class LoginMiddlewaresExtension
    {
        public static IApplicationBuilder UseLoginMiddlewares(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LoginMiddlewares>();
        }
    }
}
