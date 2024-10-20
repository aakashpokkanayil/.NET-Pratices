
namespace MyFirstApp.Custom_Middleware
{
    public class CustomMiddleware1 : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("Custom middleware 2 with UseMiddleware method starts here.\n");
            await next(context);
            await context.Response.WriteAsync("Custom middleware 2 with UseMiddleware method ends here.\n");
        }
    }
    public static class CustomMiddleware1Extension
    {
        public static IApplicationBuilder UseCustomMiddleware1(this IApplicationBuilder app)
        {
            return app.UseMiddleware<CustomMiddleware1>();
        }
    }
}
