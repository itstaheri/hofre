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
    public class ArticleCategoryMapp : IEntityTypeConfiguration<ArticleCategoryModel>
    {
        public void Configure(EntityTypeBuilder<ArticleCategoryModel> builder)
        {
            builder.HasKey(x => x.Id);
            // builder.HasMany(x => x.articles).WithMany(x => x.articleCategories);
            builder.HasMany(x => x.articleToCategories).WithOne(x => x.articleCategory).HasForeignKey(x => x.ArticleCategoryId);
        }
    }
}
