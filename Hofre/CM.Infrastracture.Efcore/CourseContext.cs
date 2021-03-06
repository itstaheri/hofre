using CM.Domain.CourseAgg;
using CM.Domain.CourseCategoryAgg;
using CM.Domain.CourseCommentAgg;
using CM.Infrastracture.Efcore.Mappings;
using Microsoft.EntityFrameworkCore;
using System;

namespace CM.Infrastracture.Efcore
{
    public class CourseContext : DbContext
    {
        public CourseContext(DbContextOptions<CourseContext> options) : base(options)
        {

        }
        public DbSet<CourseModel> courses { get; set; }
        public DbSet<CourseVideoModel> courseVideos { get; set; }
        public DbSet<CourseCategoryModel> courseCategories { get; set; }
        public DbSet<CourseCommentModel> courseComments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CourseMapp());
            builder.ApplyConfiguration(new CourseCategoryMapp());
            builder.ApplyConfiguration(new CourseVideoMapp());
            builder.ApplyConfiguration(new CourseCommentMapp());
            base.OnModelCreating(builder);
        }

    }
}
