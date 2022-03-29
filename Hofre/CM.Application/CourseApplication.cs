using CM.Application.Contract.Course;
using CM.Domain.CourseAgg;
using CM.Infrastracture.Efcore;
using Frameworks;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CM.Application
{
    public class CourseApplication : ICourseApplication
    {
        private readonly ICourseRepository _repository;
        private readonly IFileUploader _uploader;
        private readonly CourseContext _context;
        public CourseApplication(ICourseRepository repository, IFileUploader uploader, CourseContext context)
        {
            _repository = repository;
            _uploader = uploader;
            _context = context;
        }

        public void Active(long Id)
        {
            var course = _repository.GetBy(Id);
            course.Active();
            _repository.Save();
        }

        public void Create(CreateCourse commend)
        {
            Microsoft.EntityFrameworkCore.Storage.IDbContextTransaction transaction = _context.Database.BeginTransaction();

            float time = 0;
           
            var Videoname = _uploader.SingleUploader(commend.Video,"Course", commend.Subject);
            var Picturename = _uploader.SingleUploader(commend.Picture,"Course", commend.Subject);
            var course = new CourseModel(commend.Subject, commend.ShortDescription, commend.Description,
                time, commend.Teacher, commend.Price, Picturename, Videoname,
                commend.IsFree, commend.IsFinal, commend.CategoryId,commend.Slug);
            _repository.Create(course);

            var videoNames = _uploader.CourseUploader(commend.CourseVideos, commend.Subject);
            if (commend.CourseVideos != null)
            {
                foreach (var item in videoNames)
                {
                    var video = new CourseVideoModel(item, course.Id);
                    _repository.AddVideos(video);
                }
            }
            _repository.Save();
            transaction.Commit();


        }

        public void DeActive(long Id)
        {
            var course = _repository.GetBy(Id);
            course.DeActive();

            _repository.Save();
        }

        public void Edit(EditCourse commend)
        {
            float time = 0;
            var course = _repository.GetBy(commend.Id);
            if (commend.CourseVideos != null)
            {
                foreach (var item in commend.CourseVideos)
                {
                    time = time + item.Length;
                }
            }
            var Videoname = _uploader.SingleUploader(commend.Video, "Course", commend.Subject);
            var Picturename = _uploader.SingleUploader(commend.Picture, "Course", commend.Subject);
            course.Edit(commend.Subject, commend.ShortDescription, commend.Description,
                commend.CourseTime+time, commend.Teacher, commend.Price, Picturename, Videoname,
                commend.IsFree, commend.IsFinal, commend.CategoryId, commend.Slug);

           
        }

        public List<CourseViewModel> GetAll()
        {
            return _repository.GetAll();
        }

        public EditCourse GetValueForEdit(long Id)
        {
            var course = _repository.GetBy(Id);
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
                CourseVideosNames = course.courseVideos.Where(x => x.CourseId == Id)
                .Select(x => x.VideoName).ToList()
            };

        }

        public void Remove(long Id)
        {
            _repository.Remove(Id);
        }
    }
}
