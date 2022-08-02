using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Modules.Course
{
    public class CourseQueryViewModel
    {
        public long Id { get; set; }
        public string Subject { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string CourseTime { get; set; }
        public string Slug { get; set; }
        public bool IsFinal { get; set; }
        public string Teacher { get; set; }
        public double Price { get; set; }
        public int DiscountRate { get; set; }
        public double DiscountAmount { get; set; }
        public double PayAmount { get; set; }
        public bool IsFree { get; set; }
        public bool IsActive { get; set; }
        public string Picture { get; set; }
        public string Video { get; set; }
        public DateTime LastUpdate { get; set; }
        public List<CourseVideoQueryViewModel> courseVideos { get; set; }
        public long CategoryId { get; set; }
    }
}
