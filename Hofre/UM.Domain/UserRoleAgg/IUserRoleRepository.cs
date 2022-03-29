using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UM.Application.Contract.UserRole;

namespace UM.Domain.UserRoleAgg
{
    public interface IUserRoleRepository
    {
        Task Create(UserRoleModel commend);
        Task Save();
        Task Remove(long Id);
        Task<UserRoleModel> GetBy(long Id);
        Task<List<UserRoleViewModel>> GetAll();

    }
}
