using Frameworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UM.Application.Contract.User
{
    public interface IUserApplication
    {
        Task Create(CreateUser commend);
        Task Remove(long Id);
        Task<List<UserViewModel>> GetAll();
        Task<EditUser> GetValueForEdit(long Id);
        Task Edit(EditUser commend);
        Task ChangePassword(long Id, string newPassword);
        Task Active(long Id);
        Task DeActive(long Id);
        Task<LoginResult> Login(Login commend);
        Task<int> Signup(Register commend);
        
    }
}
