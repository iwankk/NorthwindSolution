using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Northwind.Web.Repository;
using Northwind.Persistence;
using Northwind.Domain;
using Northwind.Domain.Enities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.FileProviders;
using System.IO;
using Microsoft.AspNetCore.Http;
using Northwind.Domain.Base;
using Northwind.Persistence.Base;
using Northwind.Services;
using Northwind.Services.Abstraction;

namespace Northwind.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            // call Interface & Implementasi
            services.AddScoped<IEmployee, Repository.EmployeeRepository>();
            services.AddScoped<IRepositoryManager, RepositoryManager>();
            services.AddScoped<IServiceManager, ServiceManager>();
            services.AddScoped<IUtilityService, UtilityService>();
            
            //ditambahkan automapper
            services.AddAutoMapper(typeof(Startup));

            //register dbcontext
            services.AddDbContext<NorthwindContext>(opts =>
            {
                opts.UseSqlServer(Configuration["ConnectionStrings:NorthwindDb"]);
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            ///set resourec to static file
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Resources")),
                RequestPath = new PathString("/Resources")
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

/*            ShopeePopulateData.PopulateData(app);*/
        }
    }
}
