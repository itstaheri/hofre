using Frameworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TM.Domain.Ticket
{
    public class TicketModel : BaseEntity
    {
        public TicketModel(string subject, string type,string username)
        {
            Subject = subject;
            Type = type;
            IsActive = true;
            Messages = new List<MessageModel>();
            Username = username;
        }
        public void Active() => IsActive = true;
        public void DeActive() => IsActive = false;
        
        public string Subject { get;private set; }
        public string Type { get;private set; }
        public bool IsActive { get; private set; }
        public string Username { get; private set; }
        public List<MessageModel> Messages { get;private set; }

    }
}
