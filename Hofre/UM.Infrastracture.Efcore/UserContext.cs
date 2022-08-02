using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UM.Domain.UserAgg;
using UM.Domain.UserRoleAgg;
using UM.Infrastracture.Efcore.Mappings;

namespace UM.Infrastracture.Efcore
{
    public class  UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {

        }
        public DbSet<UserModel> users { get; set; }
        public DbSet<UserRoleModel> userRoles { get; set; }
        public DbSet<UserCourseModel> userCourses { get; set; }
        public DbSet<UserResetModel> userReset { get; set; }
        public DbSet<UserCouponModel> userCoupons { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserMapp());
            builder.ApplyConfiguration(new UserRoleMapp());
            builder.ApplyConfiguration(new UserCouponMapp());
            base.OnModelCreating(builder);
        }
    }
}
