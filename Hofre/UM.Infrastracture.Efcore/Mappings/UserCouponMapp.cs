using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UM.Domain.UserAgg;

namespace UM.Infrastracture.Efcore.Mappings
{
    public class UserCouponMapp : IEntityTypeConfiguration<UserCouponModel>
    {
        public void Configure(EntityTypeBuilder<UserCouponModel> builder)
        {
            builder.HasOne(x=>x.User).WithMany(x=>x.userCoupons).HasForeignKey(x=>x.UserId);
        }
    }
}
