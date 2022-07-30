using CM.Application.Contract.Course;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UM.Application.Contract.User;

namespace Query.Modules.User
{
    public interface IAccountQueryRepository
    {
        Task<bool> ChangePassword(ChangePassword commend);
        Task<bool> ForgetPassword(string entery);
        Task<string> ResetPassword(ResetPasswordViewModel commend);
        Task<AccountQueryViewModel> GetBy(string username);
        Task<AccountQueryViewModel> GetBy(long userId);
        Task UpdateProfilePicture(long userId, IFormFile picture);
        Task RemoveAllResetRequests(long UserId);
        Task<bool> ValidationResetCode(string code);



    }
}
