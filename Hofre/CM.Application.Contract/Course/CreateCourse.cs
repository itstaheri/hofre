using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.Application.Contract.Course
{
    public class CreateCourse
    {
        public string Subject { get;  set; }
        public string ShortDescription { get;  set; }
        public string Description { get;  set; }
        public string Slug { get;  set; }
        public bool IsFinal { get;  set; }
        public string Teacher { get;  set; }
        public double Price { get;  set; }
        public bool IsFree { get;  set; }
        public IFormFile Picture { get;  set; }
        public IFormFile Video { get;  set; }
        public long CategoryId { get; set; }
        public List<IFormFile> CourseVideos { get; set; }
        public List<string> CourseVideosNames { get; set; }
    }
}
