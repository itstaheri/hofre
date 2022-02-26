using AM.Domain.ArticleAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Infrastracture.Efcore.Mappings
{
    public class ArticleMapp : IEntityTypeConfiguration<ArticleModel>
    {
        public void Configure(EntityTypeBuilder<ArticleModel> builder)
        {
            builder.HasKey(x => x.Id);
            //     builder.HasMany(x => x.articleCategories).WithMany(x => x.articles);
            builder.HasMany(x => x.articleToCategories).WithOne(x => x.article).HasForeignKey(x => x.ArticleId);
            builder.HasMany(x => x.articleTags).WithOne(x => x.article).HasForeignKey(x => x.ArticleId);
        }
    }
}
