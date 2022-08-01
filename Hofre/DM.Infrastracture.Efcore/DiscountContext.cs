using DM.Domain.CustomerDiscount;
using DM.Domain.DiscountCode;
using DM.Infrastracture.Efcore.Mappings;
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
        public DbSet<DiscountCoursesModel> DiscountCourses { get; set; }
        public DbSet<DiscountCouponModel> DiscountCoupon { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new DiscountCoursesMapp());
            builder.ApplyConfiguration(new CouponMapp());

            base.OnModelCreating(builder);
        }

    }
}
