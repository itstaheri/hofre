using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OM.Application;
using OM.Application.Contract.Order;
using OM.Domain.OrderAgg;
using OM.Infrastracture.Efcore;
using OM.Infrastracture.Efcore.Repositories;
using System;

namespace OM.Configuration
{
    public class OrderBootestrapper
    {
        public static void Configuration(IServiceCollection services,string connectionstring)
        {
            services.AddDbContext<OrderContext>(x => { x.UseSqlServer(connectionstring); });
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IOrderApplication, OrderApplication>();
        }
    }
}
