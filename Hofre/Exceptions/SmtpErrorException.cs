using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    public class SmtpErrorException : Exception
    {
        public SmtpErrorException(string message) : base(message)
        {

        }
    }
}
