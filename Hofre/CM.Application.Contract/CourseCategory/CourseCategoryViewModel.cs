using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.Application.Contract.CourseCategory
{
    public class CourseCategoryViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string CreationDate { get; set; }
        public int CourseCount { get; set; }
    }
}
