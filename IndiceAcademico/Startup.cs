using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using IndiceAcademico.Infraestructure.AutoMapper;
using IndiceAcademico.Models;
using IndiceAcademico.Persistence;
using IndiceAcademico.Persistence.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

namespace IndiceAcademico
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
            services.AddAutoMapper(typeof(AutoMapperProfile).GetTypeInfo().Assembly);
            services.AddControllersWithViews();
            services.AddDbContext<AcademicDBContext>(opts =>
            {
                opts.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"])
                .EnableSensitiveDataLogging();
            });
            services.AddDbContext<AuthDBContext>(opts =>
            {
                opts.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"])
                .EnableSensitiveDataLogging();
            });
            services.AddIdentity<ApplicationUser, ApplicationRole>().AddEntityFrameworkStores<AuthDBContext>()
                .AddDefaultTokenProviders();
            services.AddControllersWithViews();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseExceptionHandler("/error/Index");
                app.UseStatusCodePages(async context => { 
                
                    
                    if(context.HttpContext.Response.StatusCode == 404)
                    {
                       context.HttpContext.Request.Path = "~/Error";
                    }
                
                });
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Account}/{action=Login}/{id?}");
                
            });
            
        }
    }
}
