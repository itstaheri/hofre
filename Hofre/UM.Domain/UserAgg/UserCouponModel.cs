using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UM.Domain.UserAgg
{
    public class UserCouponModel
    {
        public UserCouponModel(long userId, long couponId,long courseId)
        {
            UserId = userId;
            CouponId = couponId;
            CourseId = courseId;
            CreationDate = DateTime.Now;

        }

        public long Id { get;private set; }
        public long UserId { get; private set; }
        public long CouponId { get; private set; }
        public long CourseId { get; private set; }
        public DateTime CreationDate { get; private set; }
        public UserModel User { get; private set; }
    }
}
