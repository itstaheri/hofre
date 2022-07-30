using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Modules.User
{
    public class UserCourseCommentQueryViewModel
    {
        public string Username { get; set; }
        public string Text { get; set; }
        public long CourseId { get; set; }
        public string CourseName { get; set; }
        public string CreationDate { get; set; }
        public bool IsActive { get; set; }
    }
}
