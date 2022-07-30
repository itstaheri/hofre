using CM.Application.Contract.Course;
using CM.Domain.CourseAgg;
using Exceptions;
using Frameworks;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UM.Infrastracture.Efcore;

namespace CM.Infrastracture.Efcore.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly CourseContext _context;
        private readonly UserContext _user;
        private readonly IGetPath _path;
   
        private readonly IFileHelper _file;
        public CourseRepository(CourseContext context, IGetPath path,IFileHelper file, UserContext user)
        {
            _context = context;
            _path = path;
            _file = file;
            _user = user;
        }

        public async Task AddVideos(CourseVideoModel commend)
        {
            await _context.courseVideos.AddAsync(commend);
            try
            {
                await _context.SaveChangesAsync();


            }
            catch (Exception ex)
            {

                throw new SaveErrorException(ex.Message, ex.InnerException);
            }
        }

        public async Task Create(CourseModel commend)
        {
            await _context.courses.AddAsync(commend);
            try
            {
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {

                throw new SaveErrorException(ex.Message, ex.InnerException);
            }
        }

        public async Task DeleteVideo(long videoId, string folder)
        {
            var video = await _context.courseVideos.FirstOrDefaultAsync(x => x.Id == videoId);
            _context.courseVideos.Remove(video);
            
            try
            {
                await _context.SaveChangesAsync();
                await _file.DeleteFile($"//Media//Course//{folder}//{video.VideoName}");
               
              

            }
            catch (Exception ex)
            {

                throw new SaveErrorException(ex.Message, ex.InnerException);
            }

        }

        public async Task<List<CourseViewModel>> GetAll()
        {
            return await _context.courses.Include(x => x.courseCategory).Select(x => new CourseViewModel
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
                CategoryId = x.CategoryId,
                CategoryName = x.courseCategory.Name,
                Slug = x.Slug
                
            }).ToListAsync();



        }

        public async Task<List<CourseVideos>> GetAllVideos(long Id)
        {
            return await _context.courseVideos.Where(x => x.CourseId == Id)
                .Select(x=>new CourseVideos
                {
                    CourseId = x.CourseId,
                    Id = x.Id,
                    VideoName = x.VideoName,    

                }).ToListAsync();
        }

        public async Task<CourseModel> GetBy(long Id)
        {
            return await _context.courses.Include(x=>x.courseVideos).Include(x=>x.courseCategory).FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task Remove(long Id)
        {
            var course = await _context.courses.FirstOrDefaultAsync(x => x.Id == Id);
            _context.courses.Remove(course);
            var userCourses = await _user.userCourses.Where(x => x.CourseId == course.Id).ToListAsync();

            if (userCourses.Count>0 || userCourses!=null) userCourses.ForEach(userCourse => _user.userCourses.Remove(userCourse));


            try
            {
                await _context.SaveChangesAsync();
                await _file.DeleteDirectory($"{_path.Path()}//Media//Course//{course.Subject}");
                


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
