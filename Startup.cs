using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PractikaASP.Infrastructure;

namespace PractikaASP
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddSingleton<UptimeService>();
            services.AddMvc();
            services.AddControllersWithViews(service =>
            {
                service.EnableEndpointRouting = false;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
                app.UseMiddleware<BrowserTypeMiddleware>();
                app.UseMiddleware<ShortCircuitMiddleware>();
                app.UseMiddleware<ContentMiddleware>();
                app.UseMiddleware<ErrorMiddleware>();
            }
            else
                app.UseExceptionHandler("/Home/Error");
            app.UseMvc(route => 
            {
                route.MapRoute(name:"default", template: "{controller=Home}/{action=Index}/{id?}");
            });
            app.UseStaticFiles();
            //app.UseMvcWithDefaultRoute();
        }
    }
}
