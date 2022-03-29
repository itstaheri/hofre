using CM.Application.Contract.CourseCategory;
using CM.Domain.CourseCategoryAgg;
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

        public void Create(CourseCategoryModel commend)
        {
            _context.courseCategories.Add(commend);
            _context.SaveChanges();
        }

        public List<CourseCategoryViewModel> GetAll()
        {
            return _context.courseCategories.Include(x => x.courses).Select(x => new CourseCategoryViewModel
            {
                Id = x.Id,
                CreationDate = x.CreationDate.ToFarsi(),
                CourseCount = x.courses.Count,
                Name = x.Name,
                Slug = x.Slug
            }).ToList();
        }

        public CourseCategoryModel GetBy(long Id)
        {
            return _context.courseCategories.FirstOrDefault(x => x.Id == Id);
        }

        public void Remove(long Id)
        {
            var courseCategory = _context.courseCategories.FirstOrDefault(x => x.Id == Id);
            _context.courseCategories.Remove(courseCategory);
            _context.SaveChanges();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
