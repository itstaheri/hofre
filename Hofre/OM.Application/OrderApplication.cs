using Frameworks;
using Frameworks.Auth;
using Frameworks.Sms;
using OM.Application.Contract.Order;
using OM.Domain.OrderAgg;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OM.Application
{
    public class OrderApplication : IOrderApplication
    {
        private readonly IOrderRepository _repository;
        private readonly IAuth _auth;
        private readonly ISmsServices _sms;
        public OrderApplication(IOrderRepository repository, IAuth auth, ISmsServices sms)
        {
            _repository = repository;
            _auth = auth;
            _sms = sms;
        }

        public async Task<List<OrderViewModel>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<double> GetAmountBy(long Id)
        {
            var order = await _repository.GetBy(Id);
            return order.PayAmount;
        }

        public async Task<string> PaySucceded(long refId, long orderId)
        {
            var user = await _auth.CurrentUserInfo();
            var order = await _repository.GetBy(orderId);
            order.PaymentSucceeded(refId);
            await _repository.Save();
            await _sms.SendMessage(user.Number, $"خرید شما از حفره با موفقیت انجام شد کدسفارش : {order.Code}");
            return order.Code;

        }

        public async Task<long> PlaceOrder(OrderViewModel order)
        {
            var code = await CodeGenerator.Generate("OC");
            var userId = await _auth.CurrentUserId();
            var Order = new OrderModel(userId,order.CourseId, order.TotalPrice, order.DiscountAmount, order.PayAmount, code);
            await _repository.CreateOrder(Order);
            await _repository.Save();
            return Order.Id;

        }
    }
}
