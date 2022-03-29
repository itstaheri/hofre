using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Infrastracture.Efcore.Exceptions
{
    public class SaveErrorException : Exception
    {
        public SaveErrorException(string message, Exception InnerException) : base(message, InnerException)
        {

        }
    }
}
