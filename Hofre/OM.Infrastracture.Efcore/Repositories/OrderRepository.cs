using Exceptions;
using Microsoft.EntityFrameworkCore;
using OM.Application.Contract.Order;
using OM.Domain.OrderAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OM.Infrastracture.Efcore.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderContext _context;
        public OrderRepository(OrderContext context)
        {
            _context = context;
        }
        public async Task CreateOrder(OrderModel model)
        {
            await _context.orders.AddAsync(model);
            try
            {
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {

                throw new SaveErrorException(ex.Message,ex.InnerException);
            }
        }

        public Task<List<OrderViewModel>> GetAll(string Username)
        {
            throw new NotImplementedException();
        }

        public async Task<OrderModel> GetBy(long Id)
        {
            return await _context.orders.FirstOrDefaultAsync(x => x.Id == Id);

        }

        public Task RemoveOrder(long Id)
        {
            throw new NotImplementedException();
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
