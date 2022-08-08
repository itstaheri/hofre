using Frameworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UM.Domain.UserRoleAgg
{
    public class UserPermissionModel : BaseEntity
    {
        public UserPermissionModel(long roleId,string code)
        {
            RoleId = roleId;
            Code = code;
        }
        public long RoleId { get;private set; }
        public string Code { get;private set; }
        public UserRoleModel Role { get;private set; }

    }
}
