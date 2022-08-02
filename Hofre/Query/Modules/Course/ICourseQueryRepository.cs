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
        Task<CoursePageViewModel> GetAll(int pageId = 1);
        Task<CoursePageViewModel> GetByCategory(long Id,int pageId = 1);
        Task<CourseQueryViewModel> GetBy(string Slug);
        Task<CourseQueryViewModel> GetBy(long Id);
        Task JoinToCourse(long Id);
        Task<bool> FreeCourse(long Id);
        Task<bool> IsMember(long CourseId, long UserId);
        Task<List<CourseQueryViewModel>> Search(string entry);
        Task<List<CourseCategoryQueryViewModel>> GetAllCategories();

    }
}
