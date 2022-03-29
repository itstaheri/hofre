using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.Application.Contract.Course
{
    public class CourseViewModel
    {
        public long Id { get; set; }
        public string Subject { get;  set; }
        public string ShortDescription { get;  set; }
        public string Description { get;  set; }
        public float CourseTime { get;  set; }
        public bool IsFinal { get;  set; }
        public string Teacher { get;  set; }
        public double Price { get;  set; }
        public bool IsFree { get;  set; }
        public bool IsActive { get;  set; }
        public string Picture { get;  set; }
        public string Video { get;  set; }
        public string CreationDate { get; set; }
        public string LastUpdate { get;  set; }
        public string CategoryName { get;  set; }
        public long CategoryId { get;  set; }
    }
}
