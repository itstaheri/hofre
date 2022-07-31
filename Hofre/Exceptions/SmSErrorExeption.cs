using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    public class SmSErrorExeption : Exception
    {
        public SmSErrorExeption(string message) : base(message)
        {

        }
    }
}
