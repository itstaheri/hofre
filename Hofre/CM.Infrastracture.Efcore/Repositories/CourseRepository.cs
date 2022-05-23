using CM.Application.Contract.Course;
using CM.Domain.CourseAgg;
using Frameworks;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.Infrastracture.Efcore.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly CourseContext _context;

        public CourseRepository(CourseContext context)
        {
            _context = context;
        }

        public void AddVideos(CourseVideoModel commend)
        {
            _context.courseVideos.Add(commend);
            _context.SaveChanges();
        }

        public void Create(CourseModel commend)
        {
            _context.courses.Add(commend);
            _context.SaveChanges();
        }

        public async Task<List<CourseViewModel>> GetAll()
        {
            var query =await  _context.courses.Select(x => new CourseViewModel
            {
                Id = x.Id,
                Description = x.Description,
                CreationDate = x.CreationDate.ToFarsi(),
                ShortDescription = x.ShortDescription,
                Subject = x.Subject,
                IsActive = x.IsActive,
                IsFree = x.IsFree,
                Picture = x.Picture,
                Price = x.Price,
                Teacher = x.Teacher,
                IsFinal = x.IsFinal,
                Video = x.Video,
                LastUpdate = x.LastUpdate.ToFarsi(),
                CourseTime = x.CourseTime,
                CategoryId = x.CategoryId
            }).ToListAsync();

            query.ForEach(async x => { x.CategoryName =(await _context.courseCategories.FirstOrDefaultAsync(q => q.Id == x.CategoryId)).Name; });
            return query.ToList();

        }

        public CourseModel GetBy(long Id)
        {
            return _context.courses.FirstOrDefault(x => x.Id == Id);
        }

        public void Remove(long Id)
        {
            var course = _context.courses.FirstOrDefault(x => x.Id == Id);
            _context.courses.Remove(course);
            _context.SaveChanges();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
