using AM.Configuration;
using CM.Configuration;
using DM.Configuration;
using ElmahCore.Mvc;
using ElmahCore.Sql;
using Frameworks;
using Hofre.HostFrameworks;
using Hofre.MidleWares;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UM.Configuration;

namespace Hofre
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            Env = env;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Env { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            string ConnetionString = Configuration.GetConnectionString("HofreDB");
            var mvcBuilder = services.AddRazorPages();
            ArticleBootestrapper.Configuration(services, ConnetionString);
            UserBootestrapper.Configuration(services, ConnetionString);
            CourseBootestrapper.Configuration(services, ConnetionString);
            DiscountBootestrapper.Configuration(services, ConnetionString);
            #region FrameWorks
            services.AddTransient<IPasswordHasher, PasswordHasher>();
            services.AddTransient<IFileUploader, FileUploader>();
            services.AddElmah<SqlErrorLog>(option =>
            {
                //option.OnPermissionCheck = x => x.User.Identity.IsAuthenticated;
                option.LogPath = "reportlogs";
                option.ConnectionString = Configuration.GetConnectionString("LogDB");
            });
            #endregion
            #region Auth
            services.Configure<CookiePolicyOptions>(option =>
            {
                option.CheckConsentNeeded = context => true;
                option.MinimumSameSitePolicy = SameSiteMode.Lax;


            });
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, q =>
                {
                    //q.LoginPath = new PathString("/Account");
                    //q.LogoutPath = new PathString("/Account");
                    //q.AccessDeniedPath = new PathString("/AccessDenied");
                });
            services.AddAuthorization(option =>
            {
                option.AddPolicy("AdminArea", builder => builder.RequireRole(new List<string> { "1" }));
            });
            #endregion

            //SignalR
            services.AddSignalR();

            //RumtimeCompiler
            if (Env.IsDevelopment())
            {
                mvcBuilder.AddRazorRuntimeCompilation();
            }
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }
            app.UseAuthentication();
            app.UseCookiePolicy();

            //custom global exception 
            app.UseCustomExceptionHandler();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();


            app.UseElmah();

            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapDefaultControllerRoute();

            });
        }
    }
}
