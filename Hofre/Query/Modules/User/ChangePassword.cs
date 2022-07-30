using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Modules.User
{
    public class ChangePassword
    {
        public long UserId { get; set; }
        public string OldPassword { get; set; }
        [Compare("OldPassword", ErrorMessage = "کلمه ی عبور فعلی شما نادرست است!")]
        public string NewPassword { get; set; }
    }
}
