using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.Application.Contract.Course
{
    public interface ICourseApplication
    {
        Task Create(CreateCourse commend);
        Task Edit(EditCourse commend);
        Task<EditCourse> GetValueForEdit(long Id);
        Task<List<CourseViewModel>> GetAll();
        Task Remove(long Id);
        Task Active(long Id);
        Task DeActive(long Id);
        Task DeleteVideo(long videoId,string folder);
        Task<List<CourseVideos>> GetVideos(long Id);
    }
}
