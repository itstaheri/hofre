using CM.Domain.CourseAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CM.Infrastracture.Efcore.Mappings
{
    public class CourseVideoMapp : IEntityTypeConfiguration<CourseVideoModel>
    {
        public void Configure(EntityTypeBuilder<CourseVideoModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Course).WithMany(x => x.courseVideos).HasForeignKey(x => x.CourseId);
        }
    }
}
