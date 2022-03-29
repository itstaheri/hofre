using Frameworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UM.Domain.UserAgg
{
    public class UserCourseModel : BaseEntity
    {
        public UserCourseModel(long userId, long courseId)
        {
            UserId = userId;
            CourseId = courseId;
        }

        public long UserId { get;private set; }
        public long CourseId { get;private set; }
   

    }
}
