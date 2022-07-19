using CM.Application.Contract.CourseComment;
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
        Task<List<CourseQueryViewModel>> Search(string entry);
        Task<List<CourseCategoryQueryViewModel>> GetAllCategories();

    }
}
