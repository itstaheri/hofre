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
    public class UserPermissionMapp : IEntityTypeConfiguration<UserPermissionModel>
    {
        public void Configure(EntityTypeBuilder<UserPermissionModel> builder)
        {
            builder.HasOne(x => x.Role).WithMany(x => x.permissions).HasForeignKey(x => x.RoleId);
        }
    }
}
