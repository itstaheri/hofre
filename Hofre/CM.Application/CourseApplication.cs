using CM.Application.Contract.Course;
using CM.Domain.CourseAgg;
using CM.Infrastracture.Efcore;
using Frameworks;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CM.Application
{
    public class CourseApplication : ICourseApplication
    {
        private readonly ICourseRepository _repository;
        private readonly IFileHelper _uploader;
        private readonly CourseContext _context;
        private readonly IGetPath _path;
        public CourseApplication(ICourseRepository repository, IFileHelper uploader, CourseContext context, IGetPath path)
        {
            _repository = repository;
            _uploader = uploader;
            _context = context;
            _path = path;
        }

        public async Task Active(long Id)
        {
            //active the course
            var course = await _repository.GetBy(Id);
            course.Active();
            await _repository.Save();
        }

        public async Task Create(CreateCourse commend)
        {
            //waiting mode
            Microsoft.EntityFrameworkCore.Storage.IDbContextTransaction transaction = _context.Database.BeginTransaction();

            float time = 0;

            //upload uniq course picture $ video
            var Videoname = await _uploader.SingleUploader(commend.Video, "Course", commend.Subject);
            var Picturename = await _uploader.SingleUploader(commend.Picture, "Course", commend.Subject);

            //add values to courseModel class
            var course = new CourseModel(commend.Subject, commend.ShortDescription, commend.Description,
                time, commend.Teacher, commend.Price, Picturename, Videoname,
                commend.IsFree, commend.IsFinal, commend.CategoryId, commend.Slug);
            await _repository.Create(course);

            //upload courseVideos & add to database
            var videoNames = await _uploader.CourseUploader(commend.CourseVideos, commend.Subject);
            if (commend.CourseVideos != null)
            {
                foreach (var item in videoNames)
                {
                    var video = new CourseVideoModel(item, course.Id);
                    await _repository.AddVideos(video);
                }
            }
            await _repository.Save();
            transaction.Commit();


        }

        public async Task DeActive(long Id)
        {
            //Deactive course
            var course = await _repository.GetBy(Id);
            course.DeActive();

            await _repository.Save();
        }

        public async Task Delete(long Id)
        {
            var course = await _repository.GetBy(Id);
            course.Delete();
            await _repository.Save();

        }

        public async Task DeleteVideo(long videoId, string folder)
        {
            //delete special Video
            await _repository.DeleteVideo(videoId, folder);
        }

        public async Task Edit(EditCourse commend)
        {
            float time = 0;
            string Videoname = "";
            string Picturename = "";
            var course = await _repository.GetBy(commend.Id);

            if (course.Subject != commend.Subject)
            {
                var path = $"{_path.Path()}//Media//Course//";
                Directory.Move($"{path + course.Subject}", $"{path + commend.Subject}");
            }

            //sum videos length
            if (commend.CourseVideos != null)
            {
                foreach (var item in commend.CourseVideos)
                {
                    time = time + item.Length;
                }
            }
            //if exist picture or video for this course delete it and replace new picture or video
            if (commend.Picture != null)
            {
                await _uploader.DeleteFile($"//Media//Course//{course.Subject}//{course.Picture}");
                Picturename = await _uploader.SingleUploader(commend.Picture, "Course", commend.Subject);
            }
            if (commend.Video != null)
            {
                await _uploader.DeleteFile($"//Media//Course//{course.Subject}//{course.Video}");
                Videoname = await _uploader.SingleUploader(commend.Video, "Course", commend.Subject);
            }


            //call edit method
            course.Edit(commend.Subject, commend.ShortDescription, commend.Description,
                commend.CourseTime + time, commend.Teacher, commend.Price, Picturename, Videoname,
                commend.IsFree, commend.IsFinal, commend.CategoryId, commend.Slug);


            //upload courseVideos & add to database
            var videoNames = await _uploader.CourseUploader(commend.CourseVideos, commend.Subject);
            if (commend.CourseVideos != null)
            {
                foreach (var item in videoNames)
                {
                    var video = new CourseVideoModel(item, course.Id);
                    await _repository.AddVideos(video);
                }
            }

            await _repository.Save();


        }

        public async Task<List<CourseViewModel>> GetAll()
        {
            //get all courses
            return await _repository.GetAll();
        }

        public async Task<EditCourse> GetValueForEdit(long Id)
        {
            //get special courseData by Id
            var course = await _repository.GetBy(Id);
            return new EditCourse
            {
                Id = course.Id,
                Description = course.Description,
                ShortDescription = course.ShortDescription,
                CategoryId = course.CategoryId,
                CourseTime = course.CourseTime,
                IsFinal = course.IsFinal,
                IsFree = course.IsFree,
                Price = course.Price,
                Subject = course.Subject,
                Teacher = course.Teacher,
                Slug = course.Slug,
                videoName = course.Video,
                PictureName = course.Picture,
                CourseVideosNames = course.courseVideos.Where(x => x.CourseId == course.Id)
                .Select(x => x.VideoName).ToList(),
                CategoryName = course.courseCategory.Name

            };

        }

        public async Task<List<CourseVideos>> GetVideos(long Id)
        {
            return await _repository.GetAllVideos(Id);
        }

        public async Task Remove(long Id)
        {
            //remove course
            await _repository.Remove(Id);
        }
    }
}
