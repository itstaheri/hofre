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
    public class UserMapp : IEntityTypeConfiguration<UserModel>
    {
        public void Configure(EntityTypeBuilder<UserModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.userRole).WithMany(x => x.users).HasForeignKey(x => x.RoleId);
            builder.HasMany(x => x.userCoupons).WithOne(x => x.User).HasForeignKey(x => x.UserId);
           
        }
    }
}
