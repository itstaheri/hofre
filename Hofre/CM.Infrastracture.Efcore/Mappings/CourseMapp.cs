using CM.Domain.CourseAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.Infrastracture.Efcore.Mappings
{
    public class CourseMapp : IEntityTypeConfiguration<CourseModel>
    {
        public void Configure(EntityTypeBuilder<CourseModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasMany(x => x.courseVideos).WithOne(x => x.Course).HasForeignKey(x => x.CourseId);
            builder.HasOne(x => x.courseCategory).WithMany(x => x.courses).HasForeignKey(x => x.CategoryId);
        }
    }
}
