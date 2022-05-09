using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TM.Application.Contract.Ticket;
using TM.Domain.Ticket;

namespace TM.Application
{
    public class TicketApplication : ITicketApplication
    {
        private readonly ITicketRepository _repository;

        public TicketApplication(ITicketRepository repository)
        {
            _repository = repository;
        }

        public async Task CreateGroup(CreateTicket commend)
        {
            var ticket = new TicketModel(commend.Subject, commend.Type);
            await _repository.CreateGorup(ticket);
        }

        public async Task DeleteGroup(long Id)
        {
            await _repository.DeleteGorup(Id);
        }

        public async Task<List<TicketViewModel>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<List<Messages>> GetMessages(long TicketId)
        {
            return await _repository.GetMessageBy(TicketId);
        }
    }
}
