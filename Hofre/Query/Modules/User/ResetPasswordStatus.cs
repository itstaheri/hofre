using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Modules.User
{
    public static class ResetPasswordStatus
    {
        public const string  EqualPassword = "کلمه ی عبور انتخاب شده با کلمه ی عبور قبلی شما تطابق دارد!";
        public const string  ExpireTime = "تاریخ این لینک منقضی شده است ، لطفا دوباره درخواست بدید!";
        public const string SuccessfulReset = "کلمه ی عبور با موفقیت تغییر کرد،می توانید وارد حساب خود شوید.";
    }
}
