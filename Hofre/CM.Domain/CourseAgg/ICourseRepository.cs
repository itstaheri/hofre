using CM.Application.Contract.Course;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.Domain.CourseAgg
{
    public interface ICourseRepository
    {
        void Create(CourseModel commend);
        CourseModel GetBy(long Id);
        void Save();
        Task<List<CourseViewModel>> GetAll();
        void AddVideos(CourseVideoModel commend);
        void Remove(long Id);
    }
}
