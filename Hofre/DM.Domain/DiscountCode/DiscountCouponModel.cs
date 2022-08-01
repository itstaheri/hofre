using Frameworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM.Domain.DiscountCode
{
    public class DiscountCouponModel : BaseEntity
    {
        public DiscountCouponModel()
        {

        }
        public DiscountCouponModel(string title, string coupon, DateTime startDate, DateTime endDate, int discountRate)
        {
            Title = title;
            Coupon = coupon;
            StartDate = startDate;
            EndDate = endDate;
            DiscountRate = discountRate;
        }
        public void Edit(string title, string coupon, DateTime startDate, DateTime endDate, int discountRate)
        {
            Title = title;
            Coupon = coupon;
            StartDate = startDate;
            EndDate = endDate;
            DiscountRate = discountRate;
        }
        public string Title { get;private set; }
        public string Coupon { get;private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public int DiscountRate { get; private set; }
        public List<DiscountCoursesModel> DiscountCourses { get; private set; }

    }
}
