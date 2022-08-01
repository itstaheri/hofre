using DM.Application;
using DM.Application.Contract.CustomerDiscount;
using DM.Application.Contract.DiscountCoupon;
using DM.Domain.CustomerDiscount;
using DM.Domain.DiscountCode;
using DM.Infrastracture.Efcore;
using DM.Infrastracture.Efcore.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DM.Configuration
{
    public class DiscountBootestrapper
    {
        public static void Configuration(IServiceCollection services,string ConnectionString)
        {
            services.AddDbContext<DiscountContext>(x => { x.UseSqlServer(ConnectionString); });
            services.AddTransient<IDiscountRepository, DiscountRepository>();
            services.AddTransient<IDiscountApplication, DiscountApplication>();
            services.AddTransient<ICouponRepository, CoupontRepository>();
            services.AddTransient<ICouponApplication, CouponApplication>();
        }
    }
}
