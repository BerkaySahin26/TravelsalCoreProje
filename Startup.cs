using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.Container;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DocumentFormat.OpenXml.Wordprocessing;
using DTOLayer.DTOs.AnnouncementDTOs;
using Entitiy_layer.Concrete;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using TravelsalCoreProje.Models;

namespace TravelsalCoreProje
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
            services.AddLogging(x =>
                {
                    x.ClearProviders();
                    x.SetMinimumLevel(LogLevel.Debug);  //loglar� ald�k ve seviyesini bellirledik burdan sonras� home controller k�sm�nda
                    x.AddDebug();
                });

            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddScoped<IDestinationService, DestinationManager>();
            services.AddDbContext<Context>();// identity i�in ekledik 
            services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<Context>().AddErrorDescriber<CustomIdentityValidator>().AddEntityFrameworkStores<Context>();
            //services.AddScoped<ICommentService, CommentManager>(); // S�rekli newleme i�lemlerinden kurtulmak i�in service ve dal 
            //services.AddScoped<ICommentDal, EfCommentDal>();
            //services.AddScoped<IDestinationService, DestinationManager>(); // S�rekli newleme i�lemlerinden kurtulmak i�in service ve dal 
            //services.AddScoped<IDestinationDal, EfDestinationDal>();
            //services.AddScoped<IAppUserService, AppUserManager>(); // S�rekli newleme i�lemlerinden kurtulmak i�in service ve dal 
            //services.AddScoped<IAppUserDal, EfAppUserDal>();

            services.ContainerDependencies();//newlemeden k�sa yollu �ektik 

            services.AddAutoMapper(typeof(Startup));
            services.AddTransient<IValidator<AnnouncementAddDTOs>, AnnouncementValidator>();

            services.AddControllersWithViews().AddFluentValidation();

            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            });
            services.AddMvc();    // bu k�s�mlar�n anlamlar�na bak tekrardan

            services.AddScoped< IDestinationDal, EfDestinationDal>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,ILoggerFactory loggerFactory)
        {
            var path = Directory.GetCurrentDirectory();
            loggerFactory.AddFile($"{path}\\Logs\\Log1.txt");  //log i�in adres verdik

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
            app.UseStatusCodePagesWithReExecute("/ErroPage/Error404", "?code={0}");
            app.UseHttpsRedirection();
            app.UseStaticFiles();

			app.UseAuthentication();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseEndpoints(endpoints =>   //area member k�sm�
            {
                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
            });

            app.UseEndpoints(endpoints => //area admin k�sm�
            {
                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
            });
        }
    }
}
