using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.Application.Contract.Course
{
    public class CourseVideos
    {
        public long Id { get; set; }
        public long CourseId { get; set; }
        public string VideoName { get; set; }
    }
}
