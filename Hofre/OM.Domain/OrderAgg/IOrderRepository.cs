using OM.Application.Contract.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OM.Domain.OrderAgg
{
    public interface IOrderRepository
    {
        Task CreateOrder(OrderModel model);
        Task<OrderModel> GetBy(long Id);
        Task<List<OrderViewModel>> GetAll();
        Task RemoveOrder(long Id);
        Task Save();
    }
}
