using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frameworks.Smtp
{
    public interface ISmtpService
    {
        Task Send(EmailViewModel commend);
    }
}
