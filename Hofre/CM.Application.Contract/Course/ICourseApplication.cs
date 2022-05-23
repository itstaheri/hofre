using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.Application.Contract.Course
{
    public interface ICourseApplication
    {
        void Create(CreateCourse commend);
        void Edit(EditCourse commend);
        EditCourse GetValueForEdit(long Id);
        Task<List<CourseViewModel>> GetAll();
        void Remove(long Id);
        void Active(long Id);
        void DeActive(long Id);

    }
}
