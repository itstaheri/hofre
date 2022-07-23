using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Modules.Course
{
    public class CoursePageViewModel
    {
        public List<CourseQueryViewModel> Courses { get; set; }
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
    }
}
