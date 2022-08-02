using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Modules.Coupon
{
    public class UserCouponViewModel
    {
        public long UserId { get; set; }
        public long CourseId { get; set; }
        public string Coupon { get; set; }
    }
}
