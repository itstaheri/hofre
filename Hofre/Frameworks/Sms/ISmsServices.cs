using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frameworks.Sms
{
    public interface ISmsServices
    {
        Task SendMessage(string phoneNumber, string message);
    }
}
