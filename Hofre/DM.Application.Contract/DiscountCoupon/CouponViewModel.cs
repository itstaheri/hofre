using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM.Application.Contract.DiscountCoupon
{
    public class CouponViewModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Coupon { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndtDate { get; set; }
        public int DiscountRate { get; set; }
        public bool IsActive { get; set; }
    }
}
