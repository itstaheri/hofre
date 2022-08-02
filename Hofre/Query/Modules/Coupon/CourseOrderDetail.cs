using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Modules.Coupon
{
    public class CourseOrderDetail
    {
        public long CourseId { get; set; }
        public int DiscountRate { get; set; }
        public double Price { get; set; }
    }
}
