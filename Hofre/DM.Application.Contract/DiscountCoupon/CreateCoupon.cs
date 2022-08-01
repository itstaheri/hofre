using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM.Application.Contract.DiscountCoupon
{
    public class CreateCoupon
    {
        public string Title { get;  set; }
        public string Coupon { get;  set; }
        public string StartDate { get;  set; }
        public string EndDate { get;  set; }
        public int DiscountRate { get;  set; }
        public List<long> CourseIds { get; set; }
    }
}
