using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.Application.Contract.CourseCategory
{
    public interface ICourseCategoryApplication
    {
        Task Create(CreateCourseCategory commend);
        Task Edit(EditCourseCategory commend);
        Task<EditCourseCategory> GetValueForEdit(long Id);
        Task<List<CourseCategoryViewModel>> GetAll();
        Task Remove(long Id);
        
    }
}
