using CM.Infrastracture.Efcore;
using DM.Infrastracture.Efcore;
using Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UM.Domain.UserAgg;
using UM.Infrastracture.Efcore;

namespace Query.Modules.Coupon
{
    public class CouponQueryRepository : ICouponQueryRepository
    {
        private readonly DiscountContext _discount;
        private readonly CourseContext _course;
        private readonly UserContext _user;

        public CouponQueryRepository(DiscountContext discount, CourseContext course, UserContext user)
        {
            _discount = discount;
            _course = course;
            _user = user;
        }

        public async Task<PlaceCouponResult> PlaceCoupon(CourseOrderDetail courseOrder, string Coupon)
        {
            var course = await _course.courses.FirstOrDefaultAsync(x=>x.Id == courseOrder.CourseId);

            var coupon = await _discount.DiscountCoupon.FirstOrDefaultAsync(x=>x.Coupon == Coupon);
            if (coupon == null) return new PlaceCouponResult { Message = "کدتخفیف وارد شده معتبر نیست!" };
            if (coupon.EndDate < DateTime.Now) return new PlaceCouponResult { Message = "زمان استفاده از این کدتخفیف به پایان رسیده است!" };

            var check = await _discount.DiscountCourses.AnyAsync(x => x.CourseId != courseOrder.CourseId && x.CouponId == coupon.Id);
            if (check) return new PlaceCouponResult { Message = "کدتخفیف وارد شده شامل این دوره نمی شود!" };


            var discount = new PlaceCouponResult
            {
                DiscountRate = coupon.DiscountRate,
                DiscountAmount = (courseOrder.Price * coupon.DiscountRate) / 100,
                Message = $"{coupon.DiscountRate} درصد تخفیف برای شما اعمال شد.",
                IsSuccess = true

            };
            discount.PayAmount = courseOrder.Price - discount.DiscountAmount;

            return discount;
           
        }

        public async Task SaveUserCoupon(UserCouponViewModel commend)
        {
            var coupon = await _discount.DiscountCoupon.FirstOrDefaultAsync(x => x.Coupon == commend.Coupon);
            var userCoupon = new UserCouponModel(commend.UserId, coupon.Id, commend.CourseId);
            await _user.userCoupons.AddAsync(userCoupon);
            try
            {
                await _user.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new SaveErrorException(ex.Message,ex.InnerException);
            }
        }
    }
}
