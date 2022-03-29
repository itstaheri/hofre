using CM.Domain.CourseAgg;
using Frameworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.Domain.CourseCategoryAgg
{
    public class CourseCategoryModel : BaseEntity
    {
        public CourseCategoryModel(string name, string slug)
        {
            Name = name;
            Slug = slug;
        }
        public void Edit(string name, string slug)
        {
            Name = name;
            Slug = slug;
        }

        public string Name { get; private set; }
        public string Slug { get; private set; }
        public List<CourseModel> courses { get; private set; }
    }
}
