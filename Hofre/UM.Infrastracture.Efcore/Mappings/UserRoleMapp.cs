using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UM.Domain.UserRoleAgg;

namespace UM.Infrastracture.Efcore.Mappings
{
    public class UserRoleMapp : IEntityTypeConfiguration<UserRoleModel>
    {
        public void Configure(EntityTypeBuilder<UserRoleModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasMany(x => x.users).WithOne(x => x.userRole).HasForeignKey(x => x.RoleId);
            builder.HasMany(x=>x.permissions).WithOne(x=>x.Role).HasForeignKey(x => x.RoleId);
        }
    }
}
