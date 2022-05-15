using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TM.Application.Contract.Ticket
{
    public class CreateTicket
    {
        public string Subject { get; set; }
        public string Type { get; set; }
        public string Username { get; set; }
    }
}
