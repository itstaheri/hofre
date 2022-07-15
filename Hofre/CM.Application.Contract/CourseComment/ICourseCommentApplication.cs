using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.Application.Contract.CourseComment
{
    public interface ICourseCommentApplication
    {
        Task Create(CreateCourseComment commend);
        Task<List<CourseCommentViewModel>> GetAll();
        Task<List<CourseCommentViewModel>> GetCommentsBy(long Id);

        Task Active(long Id);
        Task DeActive(long Id);
        Task Remove(long Id);
    }
}
