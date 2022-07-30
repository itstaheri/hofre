using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Modules.User
{
    public class UserCourseQueryViewModel
    {
        public long CourseId { get; set; }
        public string CourseName { get; set; }
        public string Slug { get; set; }
        public string Picture { get; set; }

    }
}
