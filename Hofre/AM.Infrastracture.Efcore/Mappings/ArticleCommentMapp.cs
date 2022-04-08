using AM.Domain.ArticleCommentAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Infrastracture.Efcore.Mappings
{
    public class ArticleCommentMapp : IEntityTypeConfiguration<ArticleCommentModel>
    {
        public void Configure(EntityTypeBuilder<ArticleCommentModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x=>x.article).WithMany(x=>x.articleComments).HasForeignKey(x=>x.ArticleId);
        }
    }
}
