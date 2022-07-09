using CM.Application.Contract.CourseCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.Domain.CourseCategoryAgg
{
    public interface ICourseCategoryRepository
    {
        Task Create(CourseCategoryModel commend);
        Task<CourseCategoryModel> GetBy(long Id);
        Task Save();
        Task<List<CourseCategoryViewModel>> GetAll();
        Task Remove(long Id);
    }
}
