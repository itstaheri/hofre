using CM.Domain.CourseCategoryAgg;
using Frameworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.Domain.CourseAgg
{
    public class CourseModel : BaseEntity
    {
        protected CourseModel() { }
        public CourseModel(string subject, string shortDescription, string description, 
            float courseTime, string teacher, double price, string picture, string video,bool isFree,bool isFinal,long cateogryId, string slug)
        {
            Subject = subject;
            ShortDescription = shortDescription;
            Description = description;
            CourseTime = courseTime;
            Teacher = teacher;
            Price = price;
            Picture = picture;
            Video = video;
            IsFree = isFree;
            IsActive = true;
            IsFinal = isFinal;
            CategoryId = cateogryId;
            Slug = slug;
            LastUpdate = DateTime.Now;
        }
        public void Edit(string subject, string shortDescription, string description,
           float courseTime, string teacher, double price, string picture, string video, bool isFree, bool isFinal, long cateogryId, string slug)
        {
            Subject = subject;
            ShortDescription = shortDescription;
            Description = description;
            CourseTime = courseTime;
            Teacher = teacher;
            Price = price;
            if (!string.IsNullOrWhiteSpace(picture))
                Picture = picture;
            if (!string.IsNullOrWhiteSpace(video))
                Video = video;

            IsFree = isFree;
            IsFinal = isFinal;
            CategoryId = cateogryId;
            Slug = slug;
        }

        public void Active() => IsActive = true;
        public void DeActive() => IsActive = false;


        public string Subject { get; private set; }
        public string ShortDescription { get; private set; }
        public string Description { get; private set; }
        public float CourseTime { get; private set; }
        public string Slug { get; private set; }
        public bool IsFinal { get; private set; }
        public string Teacher { get; private set; }
        public double Price { get; private set; }
        public bool IsFree { get; private set; }
        public bool IsActive { get; private set; }
        public string Picture { get; private set; }
        public string Video { get; private set; }
        public DateTime LastUpdate { get; private set; }
        public List<CourseVideoModel> courseVideos { get; private set; }
        public CourseCategoryModel courseCategory { get; private set; }
        public long CategoryId { get; private set; }
    }
}
