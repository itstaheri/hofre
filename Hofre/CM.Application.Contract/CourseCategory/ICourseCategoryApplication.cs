using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.Application.Contract.CourseCategory
{
    public interface ICourseCategoryApplication
    {
        void Create(CreateCourseCategory commend);
        void Edit(EditCourseCategory commend);
        EditCourseCategory GetValueForEdit(long Id);
        List<CourseCategoryViewModel> GetAll();
        void Remove(long Id);
        
    }
}
