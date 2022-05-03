using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frameworks
{
    public class LoginResult
    {
        public bool Result { get; set; }
        public bool Valid { get; set; }
        public string Message { get; set; }
        public LoginResult(bool valid, bool okResult, string message)
        {
            Valid = valid;
            Result = okResult;
            Message = message;
        }

    }
}
