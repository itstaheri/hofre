using CM.Infrastracture.Efcore;
using DM.Application.Contract.DiscountCoupon;
using DM.Domain.DiscountCode;
using DM.Infrastracture.Efcore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frameworks;

namespace DM.Application
{
    public class CouponApplication : ICouponApplication
    {
        private readonly ICouponRepository _repository;
        private readonly CourseContext _course;
        private readonly DiscountContext _discount;

        public CouponApplication(ICouponRepository repository, CourseContext course, DiscountContext discount)
        {
            _repository = repository;
            _course = course;
            _discount = discount;
        }

        public async Task Create(CreateCoupon commend)
        {
            List<DiscountCoursesModel> discountCourses = new List<DiscountCoursesModel>();
            var coupon = new DiscountCouponModel(commend.Title, commend.Coupon, commend.StartDate.ToGeorgianDateTime(), commend.EndDate.ToGeorgianDateTime(), commend.DiscountRate);
            await _repository.Create(coupon);
            foreach (var item in commend.CourseIds)
            {
                discountCourses.Add(new DiscountCoursesModel(item, coupon.Id));  
            }
            await _repository.AddDiscountCourses(discountCourses);
        }

        public async Task Edit(EditCoupon commend)
        {
            List<DiscountCoursesModel> discountCourses = new List<DiscountCoursesModel>();
            var coupon = await _repository.GetBy(commend.Id);
            coupon.Edit(commend.Title,commend.Coupon,commend.StartDate.ToGeorgianDateTime(), commend.EndDate.ToGeorgianDateTime(), commend.DiscountRate);
            foreach (var item in commend.CourseIds)
            {
                discountCourses.Add(new DiscountCoursesModel(item, coupon.Id));
            }
            await _repository.Save();
        }

        public async Task<List<CouponViewModel>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<EditCoupon> GetValueForEdit(long Id)
        {
            var coupon = await _repository.GetBy(Id);
            return new EditCoupon
            {
                Title = coupon.Title,
                DiscountRate = coupon.DiscountRate,
                EndDate = coupon.EndDate.ToFarsi(),
                StartDate = coupon.StartDate.ToFarsi(),
                Coupon = coupon.Coupon,
                Id = coupon.Id
            };
        }

        public async Task Remove(long Id)
        {
            await _repository.Remove(Id);
        }
    }
}
