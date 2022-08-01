using DM.Application.Contract.DiscountCoupon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM.Domain.DiscountCode
{
    public interface ICouponRepository
    {
        Task Create(DiscountCouponModel commend);
        Task AddDiscountCourses(List<DiscountCoursesModel> commend);
        Task<List<CouponViewModel>> GetAll();
        Task Remove(long Id);
        Task<DiscountCouponModel> GetBy(long Id);
        Task Save();

    }
}
