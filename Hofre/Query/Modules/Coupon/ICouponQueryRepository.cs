using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Modules.Coupon
{
    public interface ICouponQueryRepository
    {
        Task<PlaceCouponResult> PlaceCoupon(CourseOrderDetail courseOrder, string Coupon);
        Task SaveUserCoupon(UserCouponViewModel commend);
    }
}
