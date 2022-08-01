using AM.Configuration;
using AM.Presentation.Api;
using CM.Configuration;
using CM.Presentation.Api;
using DM.Configuration;
using ElmahCore.Mvc;
using ElmahCore.Sql;
using Frameworks;
using Frameworks.Auth;
using Frameworks.Sms;
using Frameworks.Smtp;
using Frameworks.ZarinPal;
using Hofre.HostFrameworks;
using Hofre.Hubs;
using Hofre.MidleWares;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OM.Configuration;
using Query.Modules.Article;
using Query.Modules.Course;
using Query.Modules.User;
using SM.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TM.Configuration;
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

            var mvcBuilder = services.AddRazorPages().AddApplicationPart(typeof(ArticleController).Assembly)
                .AddApplicationPart(typeof(CourseController).Assembly);

            services.Configure<IISServerOptions>(option =>
            {
                option.MaxRequestBodySize = int.MaxValue;
            })
                .Configure<KestrelServerOptions>(option => { option.Limits.MaxRequestBodySize = int.MaxValue; })
            .Configure<FormOptions>(options =>
            {
                options.ValueLengthLimit = int.MaxValue;
                options.MultipartBodyLengthLimit = int.MaxValue;
                options.MultipartHeadersLengthLimit = int.MaxValue;
            });



            ArticleBootestrapper.Configuration(services, ConnetionString);
            UserBootestrapper.Configuration(services, ConnetionString);
            CourseBootestrapper.Configuration(services, ConnetionString);
            DiscountBootestrapper.Configuration(services, ConnetionString);
            SettingBootestrapper.Configuration(services, ConnetionString);
            TicketBootestrapper.Configuration(services, ConnetionString);
            OrderBootestrapper.Configuration(services, ConnetionString);
            

            #region FrameWorks
            services.AddTransient<IPasswordHasher, PasswordHasher>();
            services.AddTransient<IFileHelper, FileHelper>();
            services.AddTransient<IAuth, Auth>();
            services.AddTransient<IZarinPalFactory, ZarinPalFactory>();
            services.AddTransient<IGetPath, GetPath>();
            services.AddTransient<ISmtpService, SmtpService>();
            services.AddTransient<ISmsServices,SmsServices>();


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

                services.AddTransient<IFileHelper, FileHelper>();

                services.AddSignalR();


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
            #region Query
            services.AddTransient<IArticleQueryRepository, ArticleQueryRepository>();
            services.AddTransient<ICourseQueryRepository, CourseQueryRepository>();
            services.AddTransient<IAccountQueryRepository, AccountQueryRepository>();
            #endregion

            //SignalR
            services.AddSignalR();

            //Cors
            services.AddCors(x => x.AddPolicy("WebPolicy", o => o.WithOrigins("https://localhost:5002")));


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

            //add cors policy
            app.UseCors("WebPolicy");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapDefaultControllerRoute();
                endpoints.MapHub<ChatHub>("/chatHub");
                endpoints.MapControllers();



            });
        }
    }
}
