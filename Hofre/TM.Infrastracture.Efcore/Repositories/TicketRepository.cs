using Exceptions;
using Frameworks;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TM.Application.Contract.Ticket;
using TM.Domain.Ticket;

namespace TM.Infrastracture.Efcore.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly TicketContext _context;

        public TicketRepository(TicketContext context)
        {
            _context = context;
        }

        public async Task CreateGorup(TicketModel commend)
        {
            await _context.tickets.AddAsync(commend);
            try
            {
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {

                throw new SaveErrorException(ex.Message, ex.InnerException);
            }
        }

        public async Task DeleteGorup(long Id)
        {
            var ticket = await _context.tickets.FirstOrDefaultAsync(x => x.Id == Id);

            _context.tickets.Remove(ticket);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new SaveErrorException(ex.Message, ex.InnerException);
            }
        }

        public async Task<List<TicketViewModel>> GetAll()
        {
            return await _context.tickets.Select(x=>new TicketViewModel
            {
                IsActive = x.IsActive,
                Subject =x.Subject,
                Type = x.Type,
                CreationDate = x.CreationDate.ToFarsi()
            }).AsNoTracking().ToListAsync();

        }

        public async Task<TicketModel> GetBy(long Id)
        {
            var ticket = await _context.tickets.FirstOrDefaultAsync(x => x.Id == Id);
            return ticket != null ? ticket : throw new NotFoundException(nameof(ticket), ticket.Id);


        }

        public async Task<List<MessageModel>> GetMessageBy(long TicketId)
        {
            return await( _context.messages.Where(x => x.TicketId == TicketId)).ToListAsync();
        }

        public async Task Save()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new SaveErrorException(ex.Message, ex.InnerException);
            }
        }
    }
}
