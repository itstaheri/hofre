using DM.Domain.CustomerDiscount;
using Microsoft.EntityFrameworkCore;
using System;

namespace DM.Infrastracture.Efcore
{
    public class DiscountContext : DbContext
    {
        public DiscountContext(DbContextOptions<DiscountContext> options) : base(options)
        {

        }
        public DbSet<DiscountModel> Discounts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

    }
}
