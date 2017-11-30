using FoodApp.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FoodApp
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IGreetMessage, GreetMessage>();
            services.AddSingleton<IRestaurantData, InMemoryRestaurantData>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
                              IHostingEnvironment env,
                              IConfiguration configuration,
                              IGreetMessage greetMessage,
                              ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseMvcWithDefaultRoute();
            //default static page is index.html if nothing specified
            //app.UseDefaultFiles();
            //Allow serving up static files
            app.UseStaticFiles();

            //Add MVC with routs defined
            app.UseMvc(configureRoutes);


            app.Use(next =>
            {
                return async context =>
                {
                    logger.LogInformation("Incoming request ");
                    if (context.Request.Path.StartsWithSegments("/mvm"))
                        await context.Response.WriteAsync("Hit my code in pipe line");
                    else
                    {
                        await next(context);
                        logger.LogInformation("response outgoing");
                    }
                };
            });

            app.UseWelcomePage(new WelcomePageOptions
            {
                Path = "/wp"
            });

            app.Run(async (context) =>
            {
                var greeting = configuration["Greeting"];
                greeting = greetMessage.getMessage();
                await context.Response.WriteAsync(greeting);
            });
        }

        private void configureRoutes(IRouteBuilder routeBuilder)
        {
            routeBuilder.MapRoute("Default", "{Controller=Home}/{Action=Index}/{id?}");
        }
    }
}
