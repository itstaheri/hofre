using CM.Application.Contract.CourseComment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.Domain.CourseCommentAgg
{
    public interface ICourseCommentRepository
    {
        Task Create(CourseCommentModel commend);
        Task Remove(long Id);
        Task<List<CourseCommentViewModel>> GetAll();
        Task<CourseCommentModel> GetBy(long Id);
        Task Save();
        Task<List<CourseCommentViewModel>> GetCommentsBy(long Id);
    }
}
