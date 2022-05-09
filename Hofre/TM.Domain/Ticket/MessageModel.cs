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
        public MessageModel(string message, long userId, long ticketId)
        {
            Message = message;
            UserId = userId;
            TicketId = ticketId;
        }

        public string Message { get; private set; }
        public long UserId { get; private set; }
        public long TicketId { get; private set; }
        public TicketModel Ticket { get; private set; }

    }
}
