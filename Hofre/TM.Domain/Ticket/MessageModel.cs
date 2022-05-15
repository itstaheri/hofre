using Frameworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TM.Domain.Ticket
{
    public class MessageModel : BaseEntity
    {
        public MessageModel(string message, string username, long ticketId)
        {
            Message = message;
            Username = username;
            TicketId = ticketId;
        }

        public string Message { get; private set; }
        public string Username { get; private set; }
        public long TicketId { get; private set; }
        public TicketModel Ticket { get; private set; }

    }
}
