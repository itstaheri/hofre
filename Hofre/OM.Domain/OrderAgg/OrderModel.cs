using Frameworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OM.Domain.OrderAgg
{
    public class OrderModel : BaseEntity
    {
        public OrderModel(long userId, double totalPrice, double discountAmount, double payAmount, string code)
        {
            UserId = userId;
            TotalPrice = totalPrice;
            DiscountAmount = discountAmount;
            PayAmount = payAmount;
            Code = code;
            Isfinaly = false;
        }

        public void PaymentSucceeded(long refId)
        {
            Isfinaly = true;
            RefId = refId > 0 ? RefId = refId : RefId = 0;
        }

        public long UserId { get; private set; }
        public double TotalPrice { get; private set; }
        public double DiscountAmount { get; private set; }
        public double PayAmount { get; private set; }
        public string Code { get; private set; }
        public bool Isfinaly { get; private set; }
        public long RefId { get; private set; }





    }
}
