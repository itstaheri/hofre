using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UM.Application.Contract.User
{
    public static class UserEditStatus
    {
        public const string FailEdit = "برزورسانی مشخصات کاربر با خطا مواجه شد!";
        public const string SuccessEdit = "برزورسانی مشخصات کاربر با موفقیت انجام شد";
        public const string RepetitiveUsername = "!نام کاربری از قبل در سیستم موجود است";
        public const string RepetitivePhone = "!شماره تلفن از قبل در سیستم موجود است";
        public const string RepetitiveEmail = "!ایمیل از قبل در سیستم موجود است";
    }
}
