using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PractikaASP.Infrastructure;

namespace PractikaASP.ConfiguringApps
{
    public class StartupDevelopment
    {
        private IConfiguration Configuration { get; }
        public StartupDevelopment(IConfiguration configuration) => Configuration = configuration;
        
        public void ConfigureServices(IServiceCollection services) 
        {
            services.AddSingleton<UptimeService>();
            services.AddMvc().AddMvcOptions(option => { option.RespectBrowserAcceptHeader = true; });
            services.AddControllersWithViews(mvcOtions =>
            {
                mvcOtions.EnableEndpointRouting = false;
            });
        }


        public void ConfigureService(IServiceCollection services)
        {
            services.AddSingleton<UptimeService>();        
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseMvc(route => 
            {
                route.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
