using Microsoft.EntityFrameworkCore;
using OM.Domain.OrderAgg;
using OM.Infrastracture.Efcore.Mappings;
using System;

namespace OM.Infrastracture.Efcore
{
    public class OrderContext : DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> options) : base(options)
        {
        }
        public DbSet<OrderModel> orders { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new OrderMapp());
            base.OnModelCreating(builder);
        }
    }
}
