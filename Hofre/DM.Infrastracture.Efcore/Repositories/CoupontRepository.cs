using AM.Infrastracture.Efcore.Exceptions;
using DM.Application.Contract.DiscountCoupon;
using DM.Domain.DiscountCode;
using Frameworks;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM.Infrastracture.Efcore.Repositories
{
    public class CoupontRepository : ICouponRepository
    {
        private readonly DiscountContext _context;
        public CoupontRepository(DiscountContext context)
        {
            _context = context;
        }

        public async Task AddDiscountCourses(List<DiscountCoursesModel> commend)
        {
           
            if (commend!=null || commend.Count > 0)
            {
                #region Remove
                foreach (var item in commend)
                {
                    var discountcourse = await _context.DiscountCourses.FirstOrDefaultAsync(x => x.CouponId == item.CouponId);
                    if (discountcourse != null)
                    {
                        _context.DiscountCourses.Remove(discountcourse);
                        try
                        {
                            await _context.SaveChangesAsync();

                        }
                        catch (Exception ex)
                        {

                            throw new SaveErrorException(ex.Message, ex.InnerException);
                        }
                    }
                   
                }
                #endregion
                await _context.DiscountCourses.AddRangeAsync(commend);
                try
                {
                    await _context.SaveChangesAsync();

                }
                catch (Exception ex)
                {

                    throw new SaveErrorException(ex.Message, ex.InnerException);
                }
            }
            else
            {
                throw new NotFoundException(nameof(commend), "courses");
            }
           
           

        }

        public async Task Create(DiscountCouponModel commend)
        {
            await _context.DiscountCoupon.AddAsync(commend);
            try
            {
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {

                throw new SaveErrorException(ex.Message, ex.InnerException);
            }
        }

        public async Task<List<CouponViewModel>> GetAll()
        {
            var query =  await _context.DiscountCoupon.Select(x => new CouponViewModel
            {
                Id = x.Id,
                DiscountRate = x.DiscountRate,
                Title = x.Title,
                StartDate = x.StartDate,
                EndtDate = x.EndDate,
                Coupon = x.Coupon
            }).ToListAsync();
            foreach (var item in query)
            {
                item.IsActive = await _context.DiscountCoupon.AnyAsync(x => x.Id == item.Id && DateTime.Now < item.EndtDate);
            }
            return query;
        }

        public async Task<DiscountCouponModel> GetBy(long Id)
        {
            return await _context.DiscountCoupon.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task Remove(long Id)
        {
            var coupon = await _context.DiscountCoupon.FirstOrDefaultAsync(x => x.Id == Id);
            _context.DiscountCoupon.Remove(coupon);
            try
            {
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {

                throw new SaveErrorException(ex.Message, ex.InnerException);
            }

        }

        public async Task Save()
        {
            try
            {
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {

                throw new SaveErrorException(ex.Message, ex.InnerException);
            }
        }
    }
}
