using Frameworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.Domain.CourseAgg
{
    public class CourseVideoModel : BaseEntity
    {
        public CourseVideoModel(string videoName, long courseId)
        {
            VideoName = videoName;
            CourseId = courseId;
        }

        public string VideoName { get;private set; }
        public long CourseId { get; private set; }
        public CourseModel Course { get; private set; }
    }
}
