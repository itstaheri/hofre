using CM.Application.Contract.CourseCategory;
using CM.Domain.CourseCategoryAgg;
using Exceptions;
using Frameworks;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.Infrastracture.Efcore.Repositories
{
    public class CourseCategoryRepository : ICourseCategoryRepository
    {
        private readonly CourseContext _context;

        public CourseCategoryRepository(CourseContext context)
        {
            _context = context;
        }

        public async Task Create(CourseCategoryModel commend)
        {
           await _context.courseCategories.AddAsync(commend);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new SaveErrorException(ex.Message,ex.InnerException);
            }
        }

        public async Task<List<CourseCategoryViewModel>> GetAll()
        {
            return await _context.courseCategories.Include(x => x.courses).Select(x => new CourseCategoryViewModel
            {
                Id = x.Id,
                CreationDate = x.CreationDate.ToFarsi(),
                CourseCount = x.courses.Count,
                Name = x.Name,
                Slug = x.Slug
            }).ToListAsync();
        }

        public async Task<CourseCategoryModel> GetBy(long Id)
        {
            return await _context.courseCategories.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task Remove(long Id)
        {
            var courseCategory =await _context.courseCategories.FirstOrDefaultAsync(x => x.Id == Id);
             _context.courseCategories.Remove(courseCategory);
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
