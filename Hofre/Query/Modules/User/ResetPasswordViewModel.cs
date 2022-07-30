using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Modules.User
{
    public class ResetPasswordViewModel
    {
        public string Code { get; set; }
        public string NewPassword { get; set; }
    }
}
