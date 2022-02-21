using AM.Domain.ArticleCategoryAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Infrastracture.Efcore.Mappings
{
    public class ArticleToCategoryMapp : IEntityTypeConfiguration<ArticleToCategoryModel>
    {
        public void Configure(EntityTypeBuilder<ArticleToCategoryModel> builder)
        {
            builder.HasKey(x => new { x.ArticleCategoryId, x.ArticleId });
            builder.HasOne(x => x.articleCategory).WithMany(x => x.articleToCategories).HasForeignKey(x => x.ArticleCategoryId);
            builder.HasOne(x => x.article).WithMany(x => x.articleToCategories).HasForeignKey(x => x.ArticleId);
        }
    }
}
