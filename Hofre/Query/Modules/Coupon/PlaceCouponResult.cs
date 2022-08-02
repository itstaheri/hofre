using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Modules.Coupon
{
    public class PlaceCouponResult
    {
        public int DiscountRate { get; set; }
        public double DiscountAmount { get; set; }
        public double PayAmount { get; set; }
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
    }
}
