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
    public class ArticleTagsMapp : IEntityTypeConfiguration<ArticleTagsModel>
    {
        public void Configure(EntityTypeBuilder<ArticleTagsModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.article).WithMany(x=>x.articleTags).HasForeignKey(x=>x.ArticleId);

        }
    }
}
