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
        void Create(CourseCategoryModel commend);
        CourseCategoryModel GetBy(long Id);
        void Save();
        List<CourseCategoryViewModel> GetAll();
        void Remove(long Id);
    }
}
