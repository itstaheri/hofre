using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UM.Application.Contract.User;

namespace UM.Domain.UserAgg
{
    public interface IUserRepository
    {
        Task Create(UserModel commend);
        Task Save();
        Task Remove(long id);
        Task<UserModel> GetBy(long Id);
        Task<List<UserViewModel>> GetAll();
    }
}
