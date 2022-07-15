using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.Application.Contract.CourseComment
{
    public class EditCourseComment : CreateCourseComment
    {
        public long Id { get; set; }
    }
}
