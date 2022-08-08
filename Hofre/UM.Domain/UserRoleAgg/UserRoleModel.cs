using Frameworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UM.Domain.UserAgg;

namespace UM.Domain.UserRoleAgg
{
    public class UserRoleModel : BaseEntity
    {
        public UserRoleModel(string roleName)
        {
            RoleName = roleName;
        }
        public string RoleName { get;private set; }
        public List<UserModel> users { get; private set; }
        public List<UserPermissionModel> permissions { get; private set; }
    }
}
