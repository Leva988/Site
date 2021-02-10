using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Site.Data;
using Site.Data.Infrastructure;
using Site.Data.interfaces;
using MongoDB.Driver;
using MongoDB.Bson;
using Site.Data.Repositories;
using Site.Data.Models;
using Microsoft.Extensions.Options;

namespace Site
{
    public class Startup
    {

        private readonly IConfigurationRoot _confstring;
        public Startup(IHostingEnvironment hostenv) {
            _confstring = new ConfigurationBuilder().SetBasePath(hostenv.ContentRootPath).AddJsonFile("appsettings.json").Build();
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IAllCars,CarRepository>();
            services.AddTransient<ICarsCategory, CategoryRepository>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IAllOrders, OrdersRepository>();
            services.AddTransient<DbContext>();
            services.AddScoped<ShopCart>();
            services.AddMvc();
            services.AddMemoryCache();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            //app.UseSession();
            //app.UseMvcWithDefaultRoute();
            app.UseMvc(routes =>
                {
                  routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");
                  routes.MapRoute(name: "categoryfilter", template: "Car/{action}/{category?}", defaults: new { Controller = "Car", action = "List" });
                  });
        }
    }
}
