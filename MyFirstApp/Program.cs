using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.FileProviders;
using MyFirstApp.Custom_Middleware;

namespace MyFirstApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(new WebApplicationOptions
            {
                WebRootPath = "webroot"
            });
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

            #region use static files
            app.UseStaticFiles();
            #endregion

            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider= new PhysicalFileProvider(Path.Combine(builder.Environment.ContentRootPath, "mywebroot"))
                
            });

            #region Enabling routing
            app.UseRouting();
            #endregion

            #region Route parameter handling
            //app.UseEndpoints(endpoints => {
            //    endpoints.Map("/employee/profile/{empname=Aakash}",async (HttpContext context) => { 
            //        string? empname = Convert.ToString(context.Request.RouteValues["empname"]);
            //        if (!string.IsNullOrEmpty(empname) || !string.IsNullOrWhiteSpace(empname))
            //            await context.Response.WriteAsync($"Hi {empname} wellcome to our company");
            //    });
            //    endpoints.Map("/products/{id:int?}",async(HttpContext context) => {
            //        if (context.Request.RouteValues.ContainsKey("id"))
            //        {
            //           int? id = Convert.ToInt32(context.Request.RouteValues["id"]);
            //           await context.Response.WriteAsync($"Here is the product :{id}");
            //        }
            //        else {
            //           await context.Response.WriteAsync("Welcome to product gallery.");
            //        }
            //    });
            //    endpoints.Map("/datereport/{date:datetime}",async (HttpContext context) => {
            //        var date=Convert.ToDateTime(context.Request.RouteValues["date"]);
            //        await context.Response.WriteAsync($"Report for {date.ToShortDateString()}");
            //    });
            //});
            #endregion

            #region Coolect endpoint details
            //app.Use(async (HttpContext context,RequestDelegate next) => {
            //    var endpoints = context.GetEndpoint();
            //    await next(context);
            //});
            #endregion

            #region defining endpoints
            //app.UseEndpoints(endpoints => {
            //    endpoints.Map("/Home", async (HttpContext contect) => { await contect.Response.WriteAsync("Home Page\n"); });
            //    endpoints.MapPost("/PostHome",async (HttpContext context) => { await context.Response.WriteAsync("PostHome Page\n");});
            //    endpoints.MapGet("/GetHome", async (HttpContext context) => { await context.Response.WriteAsync("GetHome Page\n"); });
            //} );
            #endregion

            app.Run(async (HttpContext context) => {
                await context.Response.WriteAsync("Ends here.\n");
            });

            app.Run();


        }
    }
}
