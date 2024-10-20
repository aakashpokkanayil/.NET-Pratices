using Microsoft.AspNetCore.WebUtilities;
using MyFirstApp.Custom_Middleware;

namespace MyFirstApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddTransient<CustomMiddleware1>(); // register in to Iservice collection because
                                                                // this method uses dependency Injection.
            builder.Services.AddTransient<LoginMiddlewares>();
            var app = builder.Build();

            //app.MapGet("/", () => "Hello World!");
            #region Login middleware.
            //app.UseLoginMiddlewares();
            #endregion

            #region Middleware 1 with Use method and lambda expression.
            //app.Use(async (HttpContext context, RequestDelegate next) => {
            //    await context.Response.WriteAsync("Middleware 1 with Use method and lambda expression starts.\n");
            //    await next(context);
            //    await context.Response.WriteAsync("Middleware 1 with Use method and lambda expression ends.\n");
            //});
            #endregion

            #region mapping
            //app.Map("/path", appBuilder =>
            //{
            //    // Middleware for "/path" requests goes here
            //    appBuilder.UseCustomMiddleware1();
            //});
            #endregion

            #region Custom middleware 2 with UseMiddleware method.
            //app.UseMiddleware<CustomMiddleware1>();
            #endregion

            #region Custom middleware 2 with Extension method.
            //app.UseCustomMiddleware1();
            #endregion

            #region Custom middleware  with Conventional method.
            //app.UseCustomMiddleware2();
            #endregion

            #region Math Assignment middleware with Run method.
            //app.UseWhen(httpContext => httpContext.Request.Query.ContainsKey("firstNumber"),
            //    app => app.UseMathMiddleware()
            //    );
            #endregion

            #region Enabling routing
            app.UseRouting();
            #endregion

            //app.Use(async (HttpContext context,RequestDelegate next) => {
            //    var endpoints = context.GetEndpoint();
            //    await next(context);
            //});

            #region defining endpoints
            app.UseEndpoints(endpoints => {
                endpoints.Map("/Home", async (HttpContext contect) => { await contect.Response.WriteAsync("Home Page\n"); });
                endpoints.MapPost("/PostHome",async (HttpContext context) => { await context.Response.WriteAsync("PostHome Page\n");});
                endpoints.MapGet("/GetHome", async (HttpContext context) => { await context.Response.WriteAsync("GetHome Page\n"); });
            } );
            #endregion

            app.Run(async (HttpContext context) => {
                await context.Response.WriteAsync("Ends here.\n");
            });

            app.Run();


        }
    }
}
