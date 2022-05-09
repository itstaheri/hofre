using Microsoft.Extensions.DependencyInjection;
using System;
using Microsoft.EntityFrameworkCore;
using TM.Infrastracture.Efcore;
using TM.Application.Contract.Ticket;
using TM.Application;
using TM.Domain.Ticket;
using TM.Infrastracture.Efcore.Repositories;

namespace TM.Configuration
{
    public class TicketBootestrapper
    {
        public static void Configuration(IServiceCollection services,string ConnectionString)
        {
            services.AddDbContext<TicketContext>(x => { x.UseSqlServer(ConnectionString); });
            services.AddTransient<ITicketApplication,TicketApplication>();
            services.AddTransient<ITicketRepository, TicketRepository>();
        }
    }
}
