    using BussinesLayer.Abstrack;
using BussinesLayer.Concrete;
using DataAccessLayer.Abstrack;
using DataAccessLayer.Concrete.EntityFramework;
using DataAccessLayer.Concrete;
using DataAccessLayer.Context;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy; 
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaxrorCVAndBlog
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

            services.AddIdentity<AppUser, AppRole>(x => {


                x.Password.RequireUppercase = false;
                x.Password.RequireNonAlphanumeric = false;
            
            
            }).AddEntityFrameworkStores<CvBlogContext>();

            services.AddScoped<IBlogService, BlogManager>();
            services.AddScoped<IBlogDal, EFBlogDal>();

            services.AddDbContext<CvBlogContext>();

            services.AddControllersWithViews();
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


            app.UseStatusCodePagesWithReExecute("/Error/{0}");
            app.UseExceptionHandler("/Error/500");

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                 endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Default}/{action=Index}/{id?}");
            });
        }
    }
}
