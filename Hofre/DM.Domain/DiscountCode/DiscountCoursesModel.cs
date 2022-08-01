using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM.Domain.DiscountCode
{
    public class DiscountCoursesModel
    {
        public DiscountCoursesModel()
        {

        }

        public DiscountCoursesModel(long courseId, long couponId)
        {
            CourseId = courseId;
            CouponId = couponId;
        }

        public long Id { get; private set; }
        public long CourseId { get; private set; }
        public long CouponId { get; private set; }
        public DiscountCouponModel Coupon { get; private set; }
    }
}
