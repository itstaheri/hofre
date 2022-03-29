using CM.Domain.CourseCategoryAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CM.Infrastracture.Efcore.Mappings
{
    public class CourseCategoryMapp : IEntityTypeConfiguration<CourseCategoryModel>
    {
        public void Configure(EntityTypeBuilder<CourseCategoryModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasMany(x => x.courses).WithOne(x => x.courseCategory).HasForeignKey(x => x.CategoryId);
        }
    }
}
