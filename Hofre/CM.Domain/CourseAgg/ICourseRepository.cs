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
        Task Create(CourseModel commend);
        Task<CourseModel> GetBy(long Id);
        Task Save();
        Task<List<CourseViewModel>> GetAll();
        Task AddVideos(CourseVideoModel commend);
        Task Remove(long Id);
        Task DeleteVideo(long videoId,string folder);
        Task<List<CourseVideos>> GetAllVideos(long Id);
    }
}
