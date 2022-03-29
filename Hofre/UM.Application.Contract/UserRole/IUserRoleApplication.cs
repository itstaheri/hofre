using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UM.Application.Contract.UserRole
{
    public interface IUserRoleApplication
    {
        Task Create(CreateUserRole commend);
        Task Remove(long Id);
        Task<List<UserRoleViewModel>> GetAll();

    }
}
