using CM.Infrastracture.Efcore;
using DM.Application.Contract.CustomerDiscount;
using DM.Infrastracture.Efcore;
using Frameworks;
using Frameworks.Auth;
using Frameworks.ZarinPal;
using Grpc.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UM.Domain.UserAgg;
using UM.Infrastracture.Efcore;




namespace Query.Modules.Course
{
    public class CourseQueryRepository : ICourseQueryRepository
    {

        private readonly CourseContext _context;
        private readonly UserContext _user;
        private readonly IAuth _auth;
        private readonly DiscountContext _discount;
        private readonly IGetPath _path;

        public CourseQueryRepository(CourseContext context, UserContext user, IAuth auth, DiscountContext discount, IGetPath path)
        {
            _context = context;
            _user = user;
            _auth = auth;
            _discount = discount;
            _path = path;

        }

      
        public async Task<bool> FreeCourse(long Id)
        {
            return await _context.courses.AnyAsync(x => x.Id == Id && x.IsFree == true);
        }

        public async Task<List<CourseQueryViewModel>> GetAll()
        {
            long CourseLenght = 0;

            var query = await _context.courses.Where(x => x.IsActive == true).Select(x => new CourseQueryViewModel
            {
                Id = x.Id,
                IsActive = x.IsActive,
                ShortDescription = x.ShortDescription,
                CategoryId = x.CategoryId,
                IsFree = x.IsFree,
                Picture = x.Picture,
                Price = x.Price,
                Slug = x.Slug,
                Subject = x.Subject,
                Teacher = x.Teacher,

            }).AsNoTracking().ToListAsync();


            foreach (var item in query)
            {
                var courseVideos = _context.courseVideos.Where(x => x.CourseId == item.Id);

                foreach (var video in courseVideos)
                {
                    long length = new System.IO.FileInfo($"{ _path.Path()}//Media//Course//{item.Subject}//{video.VideoName}").Length;
                    CourseLenght += length;
                }
                item.CourseTime = CourseLenght.ToString();
            }


            return query;

        }

        public async Task<CourseQueryViewModel> GetBy(string Slug)
        {
            long CourseLenght = 0;
          
            var course = await _context.courses.FirstOrDefaultAsync(x => x.Slug == Slug);
            var query = new CourseQueryViewModel
            {
                Id = course.Id,
                IsActive = course.IsActive,
                ShortDescription = course.ShortDescription,
                CategoryId = course.CategoryId,
                IsFree = course.IsFree,
                Picture = course.Picture,
                Price = course.Price,
                Slug = course.Slug,
                Subject = course.Subject,
                Teacher = course.Teacher,
                Description = course.Description,
                IsFinal = course.IsFinal,
                LastUpdate = course.LastUpdate,
                Video = course.Video,

            };
            query.courseVideos = await _context.courseVideos.Where(q => q.CourseId == query.Id)
            .Select(o => new CourseVideoQueryViewModel { CourseId = o.CourseId, VideoName = o.VideoName }).ToListAsync();

            var discount = (await _discount.Discounts
                .FirstOrDefaultAsync(x => x.CourseId == query.Id));

            var courseVideos = _context.courseVideos.Where(x => x.CourseId == query.Id);
            foreach (var video in courseVideos)
            {
                long length = new System.IO.FileInfo($"{ _path.Path()}//Media//Course//{query.Subject}//{video.VideoName}").Length;
                CourseLenght += length;
            }
            query.CourseTime = CourseLenght.ToString();

            if (discount != null)
            {
                var discountAmount = (query.Price * discount.DiscountRate) / 100;
                query.PayAmount = query.Price - discountAmount;

            }
            else
            {
                query.PayAmount = query.Price;
            }

            return query;

        }

        public async Task<List<CourseQueryViewModel>> GetByCategory(long Id)
        {
            long CourseLenght = 0;
            var query = await _context.courses.Where(q => q.CategoryId == Id).Select(x => new CourseQueryViewModel
            {
                Id = x.Id,
                IsActive = x.IsActive,
                ShortDescription = x.ShortDescription,
                CategoryId = x.CategoryId,
                
                IsFree = x.IsFree,
                Picture = x.Picture,
                Price = x.Price,
                Slug = x.Slug,
                Subject = x.Subject,
                Teacher = x.Teacher,
            }).AsNoTracking().ToListAsync();

            foreach (var item in query)
            {
                foreach (var video in item.courseVideos)
                {
                    long length = new System.IO.FileInfo($"{ _path.Path()}//Media//Course//{item.Subject}//Video {video.VideoName}").Length;
                    CourseLenght += length;
                }
                item.CourseTime = CourseLenght.ToString();
            }
            return query;
        }

      

        public async Task<bool> IsMember(long CourseId, long UserId)
        {
            return await _user.userCourses.AnyAsync(x => x.CourseId == CourseId && x.UserId == UserId);
        }

        public async Task JoinToCourse(long Id)
        {
            var course = await _context.courses.FirstOrDefaultAsync(x => x.Id == Id);
            await _user.userCourses.AddAsync(new UserCourseModel(await _auth.CurrentUserId(), course.Id));
            await _user.SaveChangesAsync();
        }
    }
}
