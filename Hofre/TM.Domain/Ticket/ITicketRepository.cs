using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TM.Application.Contract.Ticket;

namespace TM.Domain.Ticket
{
    public interface ITicketRepository
    {
        Task CreateGorup(TicketModel commend);
        Task DeleteGorup(long Id);
        Task Save();
        Task<TicketModel> GetBy(long Id);
        Task<MessageModel> GetMessageBy(long TicketId);
        Task<List<TicketViewModel>> GetAll();


    }
}
