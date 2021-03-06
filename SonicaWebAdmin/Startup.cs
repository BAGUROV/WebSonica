using Core.ServerApi;
using Core.ServerApi.Contract;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SonicaWebAdmin.Middleware;
using System.Net;

namespace SonicaWebAdmin
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(CoreServerApi.Connect(endPoint: new IPEndPoint(new IPAddress(new byte[] { 172, 16, 29, 222 }), 17177)).Contract);

            services.AddControllers();
            services.AddMvc(options =>
                options.EnableEndpointRouting = false);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger, IServerApiContract contract)
        {
            app.UseMiddleware<ResponseTime>();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                logger.LogError("??????");
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseDeveloperExceptionPage();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();


            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "default", template: "{controller=Values}/{action=ValuesController}/{id?}");
                routes.MapRoute(name: "api", template: "api/{controller=Values}");
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "default", template: "{controller=Home}/{action=HomeController}/{id?}");
                routes.MapRoute(name: "api2", template: "api2/{controller=Home}");
            });
        }
    }
}
