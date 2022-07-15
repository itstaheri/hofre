using CM.Domain.CourseCommentAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.Infrastracture.Efcore.Mappings
{
    public class CourseCommentMapp : IEntityTypeConfiguration<CourseCommentModel>
    {
        public void Configure(EntityTypeBuilder<CourseCommentModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.course).WithMany(x => x.courseComments).HasForeignKey(x => x.CourseId);
        }
    }
}
