using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OM.Application.Contract.Order
{
    public interface IOrderApplication
    {
        Task<long> PlaceOrder(OrderViewModel order);
        Task<string> PaySucceded(long refId,long orderId);
        Task<double> GetAmountBy(long Id);


    }
}
