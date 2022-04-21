using Microsoft.Extensions.DependencyInjection;
using SM.Impelement;
using SM.Infrastracture.Efcore;
using System;
using Microsoft.EntityFrameworkCore;

namespace SM.Configuration
{
    public class SettingBootestrapper
    {
        public static void Configuration(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<SettingContext>(x => { x.UseSqlServer(connectionString); });
            services.AddTransient<ISettingRepository, SettingRepository>();
        }
    }
}
