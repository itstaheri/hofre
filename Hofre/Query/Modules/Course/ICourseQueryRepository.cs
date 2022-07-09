using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Modules.Course
{
    public interface ICourseQueryRepository
    {
        Task<List<CourseQueryViewModel>> GetAll();
        Task<List<CourseQueryViewModel>> GetByCategory(long Id);
        Task<CourseQueryViewModel> GetBy(string Slug);
        Task JoinToCourse(long Id);
        Task<bool> FreeCourse(long Id);
        Task<bool> IsMember(long CourseId, long UserId);
    }
}
