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

        public async Task<CoursePageViewModel> GetAll(int pageId = 1)
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
            CoursePageViewModel page = new CoursePageViewModel();
            if (query.Count >= 9)
            {
                page.CurrentPage = pageId;
                page.PageCount = (int)Math.Ceiling(query.Count / (double)9);
                page.Courses = query.OrderBy(x => x.Id).Skip((pageId - 1) * 9).Take(9).ToList();

            }
            else
            {
                page.CurrentPage = pageId;
                page.PageCount = 1;
                page.Courses = query;
            }


            return page;

        }

        public async Task<List<CourseCategoryQueryViewModel>> GetAllCategories()
        {
            return await _context.courseCategories
                .Select(x => new CourseCategoryQueryViewModel { Id = x.Id, Name = x.Name }).ToListAsync();
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

        public async Task<CoursePageViewModel> GetByCategory(long Id, int pageId = 1)
        {
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

            CoursePageViewModel page = new CoursePageViewModel();
            if (query.Count >= 9)
            {
                page.CurrentPage = pageId;
                page.PageCount = (int)Math.Ceiling(query.Count / (double)9);
                page.Courses = query.OrderBy(x => x.Id).Skip((pageId - 1) * 9).Take(9).ToList();

            }
            else
            {
                page.CurrentPage = pageId;
                page.PageCount = 1;
                page.Courses = query;
            }


            return page;
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

        public async Task<List<CourseQueryViewModel>> Search(string entry)
        {
            return await _context.courses.Where(x => x.Subject.Contains(entry)).Select(x => new CourseQueryViewModel
            {
                Id = x.Id,
                Subject = x.Subject,
                Slug = x.Slug,
                IsFree = x.IsFree,
                CategoryId = x.CategoryId,
                CourseTime = x.CourseTime.ToString(),
                Picture = x.Picture
            }).ToListAsync();


        }


    }
}
