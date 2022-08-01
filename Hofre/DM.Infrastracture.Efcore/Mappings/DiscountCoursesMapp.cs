using DM.Domain.DiscountCode;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM.Infrastracture.Efcore.Mappings
{
    public class DiscountCoursesMapp : IEntityTypeConfiguration<DiscountCoursesModel>
    {
        public void Configure(EntityTypeBuilder<DiscountCoursesModel> builder)
        {
           builder.HasOne(x=>x.Coupon).WithMany(x=>x.DiscountCourses).HasForeignKey(x=>x.CouponId);
        }
    }
}
