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
    public class CouponMapp : IEntityTypeConfiguration<DiscountCouponModel>
    {
        public void Configure(EntityTypeBuilder<DiscountCouponModel> builder)
        {
            builder.HasMany(x=>x.DiscountCourses).WithOne(x=>x.Coupon).HasForeignKey(x=>x.CouponId).OnDelete(DeleteBehavior.Cascade);

        }
    }
}
