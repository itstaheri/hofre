using AM.Infrastracture.Efcore.Exceptions;
using CM.Infrastracture.Efcore;
using DM.Application.Contract.CustomerDiscount;
using DM.Domain.CustomerDiscount;
using Frameworks;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM.Infrastracture.Efcore.Repositories
{
    public class DiscountRepository : IDiscountRepository
    {
        private readonly DiscountContext _context;
        private readonly CourseContext _course;

        public DiscountRepository(DiscountContext context, CourseContext course)
        {
            _context = context;
            _course = course;
        }

        public async Task Create(DiscountModel commend)
        {
            _context.Discounts.Add(commend);
            try
            {
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {

                throw new SaveErrorException(ex.Message,ex.InnerException);
            }
        }

        public  async Task<List<DiscountViewModel>> GetAll()
        {
            var query = await _context.Discounts.Select(x => new DiscountViewModel
            {
                Id = x.Id,
                EndDate = x.DateTimeEnd.ToFarsi(),
                startDate = x.DateTimeStart.ToFarsi(),
                CourseId = x.CourseId,
                Title = x.Title,
               
            }).ToListAsync();

            //  query.ForEach(x => x.CourseName = _course.courses.FirstOrDefault(c => x.Id == x.Id).Subject );
            foreach (var item in query)
            {
                item.CourseName = (await _course.courses.FirstOrDefaultAsync(c => c.Id == item.CourseId)).Subject;
                if (item.EndDate.ToGeorgianDateTime() < DateTime.Now)
                    item.Status = 0;
                else
                {
                    item.Status = 1;
                }
                
            }



             return query;
        }

        public async Task<DiscountModel> GetBy(long Id)
        {
            var discount = await _context.Discounts.FirstOrDefaultAsync(x => x.Id == Id);
            if (discount==null)
            {
                throw new NotFoundException(nameof(discount), discount.Id);
            }
            return discount;
        }

        public async Task Remove(long Id)
        {
            var discount = _context.Discounts.FirstOrDefault(x => x.Id == Id);
            _context.Discounts.Remove(discount);
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
