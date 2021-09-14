using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using DevTask.Models;
using Microsoft.Extensions.Hosting;
using DevTask.Models.Reposetories;
using DinkToPdf.Contracts;
using DinkToPdf;

namespace DevTask
{
    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        //  public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddMvcCore();
            services.AddMvc(options => options.EnableEndpointRouting = false);
            //Fetching Connection string from APPSETTINGS.JSON  
            var ConnectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddScoped<ICustomerRepository<Customers>, CustomerRepository>();

            //Entity Framework  
            services.AddDbContext<CustomerContext>(options => options.UseSqlServer(ConnectionString));
            services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));
            services.AddControllers();
            // services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}
            //app.UseStaticFiles();
            //app.UseMvc(route => {
            //    route.MapRoute("default", "{controller=Customer}/{action=Index}/{id?}");
            //});

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
          
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
