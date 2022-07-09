using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.Application.Contract.Course
{
    public class EditCourse : CreateCourse
    {
        public long Id { get; set; }
        public float CourseTime { get; set; }
        public string videoName { get; set; }
        public string PictureName { get; set; }
        public string CategoryName { get; set; }

    }
}
