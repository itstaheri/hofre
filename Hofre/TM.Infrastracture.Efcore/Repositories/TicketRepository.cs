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

        public async Task CreateMessage(Messages commend)
        {
            var message = new MessageModel(commend.Message, commend.Username, commend.TicketId);
            await _context.messages.AddAsync(message);
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
          
            var query = await _context.tickets.Select(x => new TicketViewModel
            {
                Id = x.Id,
                IsActive = x.IsActive,
                Subject = x.Subject,
                Type = x.Type,
                Username = x.Username,
                CreationDate = x.CreationDate.ToFarsi()
            }).AsNoTracking().ToListAsync();
            
            if (query.Count==0)
            {
                return new List<TicketViewModel>();
            }
            //query.ForEach(async x => x.LastMessage = (await _context.messages.OrderByDescending(q=>q.Id).LastOrDefaultAsync(c => c.Id == x.Id))?.Message);
            return query;

        }

        public async Task<TicketModel> GetBy(long Id)
        {
            var tickets =await _context.tickets.Where(x=>x.Id == Id).ToListAsync();
            if (tickets.Count == 0) return new TicketModel(null,null,null);
          
            if (Id <= 0)
            {
                return await _context.tickets.OrderByDescending(x=>x.Id).LastOrDefaultAsync();
            }
            var ticket = await _context.tickets.FirstOrDefaultAsync(x => x.Id == Id);
            return ticket != null ? ticket : throw new NotFoundException(nameof(ticket), ticket.Id);


        }

        public async Task<List<Messages>> GetMessageBy(long TicketId)
        {
            
            if (TicketId <= 0)
            {
                var ticket = await _context.tickets.OrderByDescending(x=>x.Id).LastOrDefaultAsync();
                if (ticket == null) return new List<Messages>();
                return await _context.messages.Where(x => x.TicketId == ticket.Id).Select(c => new Messages
                {
                    TicketId = c.TicketId,
                    Message = c.Message,
                    Username = c.Username,
                    CreationDate = c.CreationDate.ToFarsi()
                }).AsNoTracking().ToListAsync();
            }
            return await _context.messages.Where(x => x.TicketId == TicketId).Select(c => new Messages
            {
                TicketId = c.TicketId,
                Message = c.Message,
                Username = c.Username,
                CreationDate = c.CreationDate.ToFarsi()
            }).AsNoTracking().ToListAsync();

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
