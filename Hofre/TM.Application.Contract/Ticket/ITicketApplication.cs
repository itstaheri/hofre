using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TM.Application.Contract.Ticket
{
    public interface ITicketApplication
    {
        Task CreateGroup(CreateTicket commend);
        Task DeleteGroup(long Id);
        Task<List<TicketViewModel>> GetAll();
        Task<List<Messages>> GetMessages(long TicketId);
    }
}
