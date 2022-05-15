using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TM.Application.Contract.Ticket
{
    public class Messages
    {
        public string Message { get; set; }
        public string Username { get; set; }
        public long TicketId { get; set; }
        public string CreationDate { get; set; }
    }
}
