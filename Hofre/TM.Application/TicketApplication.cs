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

        public async Task CloseTicket(long Id)
        {
            var ticket = await _repository.GetBy(Id);
            ticket.DeActive();
            await _repository.Save();

        }

        public async Task CreateGroup(CreateTicket commend)
        {
            var ticket = new TicketModel(commend.Subject, commend.Type, commend.Username);
            await _repository.CreateGorup(ticket);

        }

        public async Task CreateMessage(Messages commend)
        {
            await _repository.CreateMessage(commend);
        }

        public async Task DeleteGroup(long Id)
        {
            await _repository.DeleteGorup(Id);
        }

        public async Task<List<TicketViewModel>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<TicketViewModel> GetBy(long TicketId)
        {
            var ticket = await _repository.GetBy(TicketId);

            return new TicketViewModel
            {
                Id = ticket.Id,
                IsActive = ticket.IsActive,
                Subject = ticket.Subject,
                Type = ticket.Type,
                Username = ticket.Username,
            };
        }

        public async Task<List<Messages>> GetMessages(long TicketId)
        {
            return await _repository.GetMessageBy(TicketId);
        }

        public async Task OpenTicket(long Id)
        {
            var ticket = await _repository.GetBy(Id);
            ticket.Active();
            await _repository.Save();
        }
    }
}
