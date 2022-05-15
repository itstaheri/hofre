using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TM.Application.Contract.Ticket
{
    public class TicketViewModel
    {
        public long Id { get;  set; }
        public string Subject { get;  set; }
        public string Type { get;  set; }
        public bool IsActive { get;  set; }
        public string CreationDate { get;  set; }
        public string Username { get;  set; }
        public string LastMessage { get;  set; }
    }
}
