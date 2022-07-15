using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frameworks.Auth
{
    public interface IAuth
    {
        Task SignIn(AuthViewModel account);
        Task SignOut();
        Task<bool> IsAuthenticated();
        Task<long> CurrentUserId();
        Task<string> CurrentUserRole();
        Task<AuthViewModel> CurrentUserInfo();
        Task<string> CurrentUserName();


    }
}
